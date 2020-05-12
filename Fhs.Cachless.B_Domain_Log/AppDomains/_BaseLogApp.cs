using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.B_Domain_Log.AppModels;
using Fhs.Cachless.C_DataAccess_Log.DA;
using Fhs.Cachless.C_DataAccess_Log.DBModel;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;

namespace Fhs.Cachless.B_Domain_Log.AppDomains
{
    public abstract class _BaseLogApp
    {
        #region Variables

        public int Id
        {
            get
            {
                try
                {
                    return GetDataId();
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                    return 0;
                }
            }
        }

        public Guid ObjectId
        {
            get
            {
                try
                {
                    return GetDataObjectId();
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                    return Guid.Empty;
                }
            }
        }

        public ObjectTypeEnum ObjectType
        {
            get
            {
                try
                {
                    return GetDataObjectType();
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                    return ObjectTypeEnum.Error;
                }
            }
        }

        public IdentifyClass IdentifyData
        {
            get
            {
                try
                {
                    return GetDataIdentifyData();
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                    return new IdentifyClass();
                }
            }
        }

        public String DataName
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(IdentifyData.DataName) ||
                        String.IsNullOrWhiteSpace(IdentifyData.DataName))
                        return ObjectType.ToString();

                    return IdentifyData.DataName;
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                    return ObjectType.ToString();
                }
            }
        }


        public bool HasError
        {
            get
            {
                if (_exceptionDataList == null || _exceptionDataList.Count == 0) return false;

                return true;
            }
        }

        public bool StaticHasError
        {
            get
            {
                if (_staticExceptionDataList == null || _staticExceptionDataList.Count == 0)
                    return false;

                return true;
            }
        }

        private static List<Exception> _staticExceptionDataList = new List<Exception>();
        private List<Exception> _exceptionDataList = new List<Exception>();

        #endregion

        #region Exception Handling Methods

        public List<Exception> GetExceptionDataList()
        {
            var result = new List<Exception>();
            try
            {
                if (_exceptionDataList == null)
                    return new List<Exception>();

                result.AddRange(_exceptionDataList);
            }
            catch (Exception e)
            {
                result.Add(e);
            }

            return result;
        }

        protected void AddExceptionData(Exception ex, bool saveInDb = true)
        {
            if (_exceptionDataList == null)
                _exceptionDataList = new List<Exception>();

            _exceptionDataList.Add(ex);
            ThisAppContext.AddLogInDb(ex);
        }

        protected void AddExceptionDataRange(List<Exception> exceptionList, bool saveInDB = true)
        {
            foreach (var exData in exceptionList)
                AddExceptionData(exData, saveInDB);

        }

        public void CleanExceptionDataList()
        {
            _exceptionDataList = new List<Exception>();
        }

        public static List<Exception> GetStaticExceptionDataList()
        {
            var result = new List<Exception>();
            try
            {
                if (_staticExceptionDataList == null)
                    return new List<Exception>();

                result.AddRange(_staticExceptionDataList);
            }
            catch (Exception e)
            {
                result.Add(e);
            }

            return result;
        }

        public static void CleanStaticExceptionDataList()
        {
            _staticExceptionDataList = new List<Exception>();
        }

        protected static void AddStaticExceptionData(Exception ex, bool saveInDb = true)
        {
            if (_staticExceptionDataList == null)
                _staticExceptionDataList = new List<Exception>();

            _staticExceptionDataList.Add(ex);
            ThisAppContext.AddLogInDb(ex);
        }

        protected static void AddStaticExceptionDataRange(List<Exception> exceptionList, bool saveInDB = true)
        {
            foreach (var exData in exceptionList)
                AddStaticExceptionData(exData, saveInDB);

        }

        #endregion

        #region abstract Methods

        protected abstract int GetDataId();
        protected abstract Guid GetDataObjectId();
        protected abstract ObjectTypeEnum GetDataObjectType();
        protected abstract String GetDataName();
        protected abstract IdentifyClass GetDataIdentifyData();

        #endregion

        #region Helper Methods
        
        public static DataBaseConnectionStatus ConnectionStatus()
        {
            return _BaseLogDA.ConnectionStatus();
        }

        public static void AddAppRequestLog(AppRequestLog appRequestLog)
        {
            new AppRequestLogDA().InsertAppRequestLogTable((AppRequestLogTable)appRequestLog.MakeDataBaseModel());
        }

        #endregion


    }
}
