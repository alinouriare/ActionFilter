using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.D_Common.Model.BaseModels;
using Fhs.Cachless.E_Utility.PublicUtility;
using Newtonsoft.Json;

namespace Fhs.Cachless.B_Domain_Log.AppModels
{
    public abstract class _BaseAppLogModel
    {
        #region Variables

        public int Id { get; set; }
        public Guid ObjectId { get; set; }
        public ObjectTypeEnum ObjectType { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public IdentifyClass IdentifyData
        {
            get
            {
                try
                {
                    return new IdentifyClass(Id, ObjectId, ObjectType, GetObjectName());
                }
                catch (Exception ex)
                {
                    return SafeIdentifyData;
                }

            }
        }
        public IdentifyClass SafeIdentifyData
        {
            get
            {
                try
                {
                    return new IdentifyClass(Id, ObjectId, ObjectType);
                }
                catch (Exception ex2)
                {
                    return new IdentifyClass(0, Guid.Empty, ObjectTypeEnum.Null, ex2.ToString());
                }
            }
        }
        [JsonIgnore]
        public String PersianCreateDate
        {
            get
            {
                try
                {
                    return PublicUtilities.ConvertDateTimeToJalali(CreateTime);
                }
                catch (Exception ex)
                {
                    AddExceptionData(ex);
                    return "";
                }
            }
        }

        [JsonIgnore]
        public String PersianLastUpdateDate
        {
            get
            {
                try
                {
                    return PublicUtilities.ConvertDateTimeToJalali(LastUpdateTime);
                }
                catch (Exception ex)
                {
                    AddExceptionData(ex);
                    return "";
                }
            }
        }

        public bool HasError
        {
            get
            {
                if (_exceptionDataList == null ||
                    _exceptionDataList.Count == 0) return false;
                return true;
            }
        }

        public List<Exception> ExceptionDataList
        {
            get
            {
                if (_exceptionDataList == null) return new List<Exception>();

                var result = new List<Exception>();

                result.AddRange(_exceptionDataList);
                return result;
            }
        }

        private List<Exception> _exceptionDataList = new List<Exception>();

        public static List<Exception> StaticExceptionDataList
        {
            get
            {
                if (_staticExceptionDataList == null) return new List<Exception>();

                var result = new List<Exception>();

                result.AddRange(_staticExceptionDataList);
                return result;
            }
        }

        private static List<Exception> _staticExceptionDataList = new List<Exception>();

        #endregion

        #region Constructors

        public _BaseAppLogModel(ObjectTypeEnum objType)
        {
            MakeDefaults(objType);

        }

        public _BaseAppLogModel(ObjectTypeEnum objType, Object obj)
        {
            MakeDefaults();

            if (obj == null ||
                !(obj is _BaseDbModel)) return;

            var model = (_BaseDbModel)obj;

            if (model.ObjectType != objType) return;

            Id = model.Id;
            ObjectId = model.ObjectId;
            ObjectType = model.ObjectType;

            CreateTime = model.CreateTime;
            LastUpdateTime = model.LastUpdateTime;
        }

        #endregion

        #region Methods

        public static _BaseAppLogModel GetBaseDataByObjecType(ObjectTypeEnum objType, Object objData = null)
        {
            try
            {

                var className = "Fhs.Cachless.B_Domain_Log.AppModels." + objType.ToString();



                var typeData = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                from type in assembly.GetTypes()
                                where type.FullName == className
                                select type).FirstOrDefault();

                if (typeData == null)
                    return null;

                if (typeData.BaseType != null &&
                    typeData.BaseType.Name != typeof(_BaseAppLogModel).Name)
                    return null;


                var model = (_BaseAppLogModel)Activator.CreateInstance(typeData, new object[] { objData });


                return model;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }

        public object MakeDataBaseModel()
        {
            try
            {
                var data = _MakeDAModel();

                if (!(data is _BaseDbModel) ||
                    ((_BaseDbModel)data).ObjectType != ObjectType) return null;

                var model = (_BaseDbModel)data;

                model.Id = Id;
                model.ObjectId = ObjectId;
                model.CreateTime = CreateTime;
                model.LastUpdateTime = LastUpdateTime;

                return model;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return null;
            }
        }

        #endregion

        #region Abstract Methods

        protected abstract Object _MakeDAModel();
        public abstract String GetObjectName();
        public abstract String GetObjectDescription();

        #endregion

        #region Helper Methods

        private void MakeDefaults(ObjectTypeEnum objType = ObjectTypeEnum.Null)
        {
            Id = 0;
            ObjectId = Guid.Empty;
            ObjectType = objType;
            CreateTime = DateTime.Now;
            LastUpdateTime = DateTime.Now;
        }

        public override string ToString()
        {
            try
            {
                return GetObjectName();
            }
            catch (Exception ex)
            {
                try
                {

                    return IdentifyData.ToString();
                }
                catch (Exception ex2)
                {
                    return "";
                }
            }

        }

        #endregion

        #region Exception Handling

        public void AddExceptionData(Exception exData)
        {
            if (_exceptionDataList == null)
                _exceptionDataList = new List<Exception>();
            try
            {
                _exceptionDataList.Add(exData);
                ThisAppContext.AddLogInDb(exData);
            }
            catch (Exception ex)
            {
                try
                {
                    _exceptionDataList.Add(ex);
                }
                catch (Exception)
                {

                }
            }

        }
        public void CleanExceptionData()
        {
            _exceptionDataList = new List<Exception>();
        }

        public static void AddStaticExceptionData(Exception exData)
        {
            if (_staticExceptionDataList == null)
                _staticExceptionDataList = new List<Exception>();
            try
            {
                _staticExceptionDataList.Add(exData);
                ThisAppContext.AddLogInDb(exData);
            }
            catch (Exception ex)
            {
                try
                {
                    _staticExceptionDataList.Add(ex);

                }
                catch (Exception)
                {
                }
            }
        }
        public static void CleanStaticExceptionData()
        {
            _staticExceptionDataList = new List<Exception>();
        }

        #endregion
    }
}
