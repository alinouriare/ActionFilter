using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.C_DataAccess_Log.DBModel;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.D_Common.Model.BaseModels;

namespace Fhs.Cachless.C_DataAccess_Log.DA
{
    public abstract class _BaseLogDA
    {
        #region Variables

        public Guid DaId { get { return _dataAccessId; } }
        protected ObjectTypeEnum ObjectType { get; set; }
        protected Fhs_CachLessDBEntities_Log ContextDb { get; set; }
        public List<Exception> ExceptionDataList
        {
            get { return GetExceptionDataList(); }
        }
        public bool HasError
        {
            get
            {
                if (_exceptionDataList == null ||
                    _exceptionDataList.Count == 0)
                    return false;

                return true;
            }
        }

        protected static readonly int MAXTRYTOMAKETREECODEID = 2000;
        public static readonly String TREESEPRATOR = "#";

        private static String ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["Fhs_CachLessDBEntities_Log"].ToString();
                }
                catch (Exception e)
                {
                    AddStaticExceptionData(e);
                    return "";
                }

            }
        }

        private List<Exception> _exceptionDataList = new List<Exception>();
        private static List<Exception> _staticExceptionDataList = new List<Exception>();
        private Guid _dataAccessId = Guid.NewGuid();

        #endregion

        #region Constructors

        public _BaseLogDA(ObjectTypeEnum objType)
        {
            MakeDefaults(objType);
        }

        #endregion

        #region _BaseDA Methods

        public static _BaseDbModel GetBaseDataByObjectId(Guid objId, ObjectTypeEnum objType)
        {
            try
            {
                var daObj = GetBaseDataAccessByObjectType(objType);
                if (daObj != null)
                    return daObj.GetBaseDbModelById(objId);

                return null;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        public static _BaseDbModel GetBaseDataByObjectId(int id, ObjectTypeEnum objType)
        {
            try
            {
                var daObj = GetBaseDataAccessByObjectType(objType);
                if (daObj != null)
                    return daObj.GetBaseDbModelById(id);

                return null;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        public static _BaseDbModel GetBaseDataByObjectIdInEntireDB(Guid objId)
        {
            try
            {
                var enumValues = Enum.GetValues(typeof(ObjectTypeEnum));
                for (int i = 0; i < enumValues.Length; i++)
                {
                    var item = (ObjectTypeEnum)enumValues.GetValue(i);
                    if (item == ObjectTypeEnum.Error || item == ObjectTypeEnum.Null)
                        continue;

                    var daObj = GetBaseDataAccessByObjectType(item);
                    var data = daObj.GetBaseDbModelById(objId);

                    if (data != null)
                        return data;
                }

                return null;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        #endregion

        #region Abstract Methods

        public abstract List<_BaseDbModel> GetAllBaseDbModel();
        public abstract _BaseDbModel GetBaseDbModelById(int id);
        public abstract _BaseDbModel GetBaseDbModelById(Guid id);

        public abstract IdentifyClass InsertBaseDbModel(_BaseDbModel data);
        public abstract bool UpdateBaseDbModel(_BaseDbModel data);

        public abstract bool DeleteBaseDbModel(int id);
        public abstract bool DeleteBaseDbModel(Guid id);

        #endregion

        #region Exception Handling

        public List<Exception> GetExceptionDataList()
        {
            var result = new List<Exception>();

            result.AddRange(_exceptionDataList);

            return result;
        }
        protected void AddExceptionData(Exception ex, IdentifyClass dataId = null)
        {
            if (_exceptionDataList == null)
                _exceptionDataList = new List<Exception>();

            _exceptionDataList.Add(ex);

            ThisAppContext.AddLogInDb(ex, dataId);
        }
        public void CleanExceptionDataList()
        {
            _exceptionDataList = new List<Exception>();
            ThisAppContext.CleanInnerExceptionDataList();
        }
        public static List<Exception> GetStaticExceptionDataList()
        {
            var result = new List<Exception>();

            result.AddRange(_staticExceptionDataList);

            return result;
        }
        protected static void AddStaticExceptionData(Exception ex, IdentifyClass dataId = null)
        {
            if (_staticExceptionDataList == null)
                _staticExceptionDataList = new List<Exception>();

            _staticExceptionDataList.Add(ex);

            ThisAppContext.AddLogInDb(ex, dataId);
        }
        public static void CleanStaticExceptionDataList()
        {
            _staticExceptionDataList = new List<Exception>();
            ThisAppContext.CleanInnerExceptionDataList();
        }

        #endregion

        #region Helper Methods
        
        public static DataBaseConnectionStatus ConnectionStatus()
        {
            var result = new DataBaseConnectionStatus();
            try
            {
                using (var contextMainDB = GetDbBaseContext())
                {
                    result.IsMainDBConnect = contextMainDB.Database.Exists();
                }
                result.IsLogDBConnect = true;
            }
            catch (Exception e)
            {
                result.MainDBConnectionException = e;
            }


            return result;
        }
        private void MakeDefaults(ObjectTypeEnum objType)
        {
            try
            {
                ObjectType = objType;
                ContextDb = GetDbBaseContext(objType);
            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }
        public static _BaseLogDA GetBaseDataAccessByObjectType(ObjectTypeEnum objType)
        {
            try
            {
                var className = "Fhs.Cachless.C_DataAccess_Log.DA." + objType.ToString() + "DA";

                var typeData = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                from type in assembly.GetTypes()
                                where type.FullName == className
                                select type).FirstOrDefault();

                if (typeData == null)
                    return null;

                if (typeData.BaseType != null &&
                    typeData.BaseType.Name != typeof(_BaseLogDA).Name)
                    return null;


                return (_BaseLogDA)Activator.CreateInstance(typeData);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        protected static Fhs_CachLessDBEntities_Log GetDbBaseContext(ObjectTypeEnum objType = ObjectTypeEnum.Null)
        {
            Fhs_CachLessDBEntities_Log context = null;

            context = new Fhs_CachLessDBEntities_Log(ConnectionString);

            return context;
        }
        #endregion
    }
}
