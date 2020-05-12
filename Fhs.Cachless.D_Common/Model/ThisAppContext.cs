using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Interfaces;
using Fhs.Cachless.E_Utility.EncryptDecryptUtility.Models;

namespace Fhs.Cachless.D_Common.Model
{
    public static class ThisAppContext
    {
        #region Inner And Public Variables
        public static List<Exception> InnerExceptionDataList
        {
            get
            {
                try
                {
                    if (_exceptionDataList == null)
                        _exceptionDataList = new List<Exception>();

                    var result = new List<Exception>();

                    result.AddRange(_exceptionDataList);
                    return result;
                }
                catch (Exception e)
                {
                    return new List<Exception>();
                }
            }
        }

        private static IThisAppContextInterface _context = null;
        private static List<Exception> _exceptionDataList = new List<Exception>();
        #endregion

        #region Application Name And Title

        public static String ApplicationName
        {
            get
            {
                try
                {
                    if (_context != null)
                        return _context.GetApplicationName();
                }
                catch (Exception e)
                {
                    AddInnerException(e);
                }

                return "FHS Framework 1.0";
            }
        }
        public static String ApplicationTitle
        {
            get
            {
                try
                {
                    if (_context != null)
                        return _context.GetApplicationTitle();

                }
                catch (Exception e)
                {
                    AddInnerException(e);
                }

                return "FHS Framework 1.0";
            }
        }
        public static String ApplicationVersion
        {
            get
            {
                try
                {
                    if (_context != null)
                        return _context.GetApplicationVersion();

                }
                catch (Exception e)
                {
                    AddInnerException(e);
                }

                return "1.0";
            }
        }

        #endregion

        #region Application File Management

        public static String GetApplicationBaseRoot()
        {
            try
            {
                if (_context != null)
                    return _context.GetApplicationBaseRoot();

            }
            catch (Exception e)
            {
                AddInnerException(e);
            }

            return "";
        }
        public static String GetApplicationTempRelativeAddress()
        {
            try
            {
                if (_context != null)
                    return _context.GetApplicationTempRelativeAddress();

            }
            catch (Exception e)
            {
                AddInnerException(e);
            }

            return "";
        }
        public static String GetApplicationLogFileRootRelativeAddress()
        {
            try
            {
                if (_context != null)
                    return _context.GetApplicationLogFileRootRelativeAddress();

            }
            catch (Exception e)
            {
                AddInnerException(e);
            }

            return "";
        }
        public static String GetApplicationConfigFileRootRelativeAddress()
        {
            try
            {
                if (_context != null)
                    return _context.GetApplicationConfigFileRootRelativeAddress();

            }
            catch (Exception e)
            {
                AddInnerException(e);
            }

            return "";
        }

        #endregion

        #region UserData Managment
        public static IdentifyClass UserIdentifyData
        {
            get
            {
                try
                {
                    var userId = _context.GetCurrentUserId();
                    var userName = _context.GetCurrentUserName();
                    var userNickName = _context.GetCurrentUserNickName();
                    var userIdentifyName = "";

                    if (userId != null &&
                        !String.IsNullOrWhiteSpace(userName) &&
                        !String.IsNullOrEmpty(userName))
                        userIdentifyName = " (" + userName + ")";

                    if (userId != null &&
                        !String.IsNullOrWhiteSpace(userNickName) &&
                        !String.IsNullOrEmpty(userNickName))
                        userIdentifyName += " (" + userNickName + ")";

                    if (userId != null)
                        userId.DataName = userIdentifyName;

                    return userId;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static String UserName
        {
            get
            {
                try
                {
                    if (_context == null)
                        return "";

                    return _context.GetCurrentUserName();
                }
                catch (Exception e)
                {
                    AddLogInDb(e);
                    return "";
                }
            }
        }
        public static String UserNickName
        {
            get
            {
                try
                {
                    if (_context == null)
                        return "";

                    return _context.GetCurrentUserNickName();
                }
                catch (Exception e)
                {
                    AddLogInDb(e);
                    return "";
                }
            }
        }

        #endregion

        #region Exception Handling Methods

        public static bool AddLogInDb(InformationLog infoLog, IdentifyClass userId ,IdentifyClass dataId = null)
        {
            try
            {
                if (_context == null)
                {
                    AddInnerException(new Exception("ThisAppContextInterface was not override in SSC.D_Common.Model.ThisAppContext"));
                    return false;
                }

                if (!_context.AddInformationLogInDataBase(infoLog, userId, dataId))
                    return AddLogInFile(infoLog, dataId);
            }
            catch (Exception e)
            {
                try
                {
                    var infoLog2 = new InformationLog(e);

                    AddLogInFile(infoLog2);
                    return AddLogInFile(infoLog, dataId);
                }
                catch (Exception innerExData)
                {
                    AddInnerException(innerExData);
                }
            }

            return false;
        }
        public static bool AddLogInDb(InformationLog infoLog, IdentifyClass dataId = null)
        {
            try
            {
                if (_context == null)
                {
                    AddInnerException(new Exception("ThisAppContextInterface was not override in SSC.D_Common.Model.ThisAppContext"));
                    return false;
                }

                if (!_context.AddInformationLogInDataBase(infoLog, UserIdentifyData, dataId))
                    return AddLogInFile(infoLog, dataId);
            }
            catch (Exception e)
            {
                try
                {
                    var infoLog2 = new InformationLog(e);

                    AddLogInFile(infoLog2);
                    return AddLogInFile(infoLog, dataId);
                }
                catch (Exception innerExData)
                {
                    AddInnerException(innerExData);
                }
            }

            return false;
        }
        public static bool AddLogInDb(Exception exData, IdentifyClass dataId = null)
        {
            return AddLogInDb(new InformationLog(exData), dataId);
        }

        public static bool AddLogInFile(InformationLog infoLog, IdentifyClass dataId = null)
        {
            try
            {
                if (_context == null)
                {
                    AddInnerException(new Exception("ThisAppContextInterface was not override in SSC.D_Common.Model.ThisAppContext"));
                    return false;
                }

                if (!_context.AddInformationLogInFile(infoLog, UserIdentifyData, dataId))
                    throw new Exception("Can not save InformationLog in File Source", new Exception(infoLog.SerializeObject()));

            }
            catch (Exception e)
            {
                AddInnerException(e);
            }

            return false;
        }
        public static bool AddLogInFile(Exception exData, IdentifyClass dataId = null)
        {
            return AddLogInFile(new InformationLog(exData), dataId);
        }

        private static void AddInnerException(Exception exData)
        {
            if (_exceptionDataList == null)
                _exceptionDataList = new List<Exception>();

            _exceptionDataList.Add(exData);
        }
        public static void CleanInnerExceptionDataList()
        {
            _exceptionDataList = new List<Exception>();
        }

        #endregion

        #region Configuration Management
        public static bool AddSystemConfig(ConfigurationData configData)
        {
            try
            {
                if (configData == null ||
                    _context == null) return false;

                return _context.AddConfigData(null, configData.GroupName, configData.Name, configData.Value);

            }
            catch (Exception e)
            {
                AddInnerException(e);
                return false;
            }
        }
        public static ConfigurationData GetSystemConfig(string groupName, string configName)
        {
            try
            {
                if (_context == null)
                    return null;

                var item = _context.GetConfigData((Guid?)null, groupName, configName);
                if (item != null)
                    return item;

                return null;
            }
            catch (Exception e)
            {
                AddInnerException(e);
                return null;
            }
        }
        public static T GetSystemConfig<T>(string groupName, string configName, T defaultValue)
        {
            try
            {
                if (_context == null)
                    return defaultValue;

                var item = _context.GetConfigData((Guid?)null, groupName, configName);

                if (item != null &&
                    item.Value is T)
                    return (T)item.Value;

                return defaultValue;
            }
            catch (Exception e)
            {
                AddInnerException(e);
                return defaultValue;
            }
        }

        public static bool AddUserSystemConfig(ConfigurationData configData)
        {
            try
            {
                if (_context == null)
                    return false;

                var userIdIdentify = UserIdentifyData;

                if (userIdIdentify == null ||
                    userIdIdentify.IsEmpty)
                    return false;

                return _context.AddConfigData(userIdIdentify.DataObjectId, configData.GroupName, configData.Name, configData.Value);

            }
            catch (Exception e)
            {
                AddInnerException(e);
                return false;
            }
        }
        public static ConfigurationData GetUserConfig(string groupName, string configName)
        {
            try
            {
                if (_context == null)
                    return null;

                var userIdIdentify = UserIdentifyData;

                if (userIdIdentify == null ||
                    userIdIdentify.IsEmpty)
                    return null;

                var item = _context.GetConfigData(userIdIdentify.DataObjectId, groupName, configName);
                if (item != null)
                    return item;

                return null;
            }
            catch (Exception e)
            {
                AddInnerException(e);
                return null;
            }
        }
        public static T GetUserConfig<T>(string groupName, string configName, T defaultValue)
        {
            try
            {
                if (_context == null)
                    return defaultValue;

                var userIdIdentify = UserIdentifyData;

                if (userIdIdentify == null ||
                    userIdIdentify.IsEmpty)
                    return defaultValue;

                var item = _context.GetConfigData(userIdIdentify.DataObjectId, groupName, configName);
                if (item != null &&
                    item.Value is T)
                    return (T)item.Value;

                return defaultValue;
            }
            catch (Exception e)
            {
                AddInnerException(e);
                return defaultValue;
            }
        }

        #endregion

        #region Token Handling

        public static bool IsEncryptDataActive()
        {
            if (_context == null) return false;

            return _context.IsEncryptDataActive();
        }

        public static TokenHelper GetMainToken()
        {
            try
            {
                if (_context == null) return new TokenHelper("NULL", "NULL");

                return _context.GetMainToken();

            }
            catch (Exception e)
            {
                AddInnerException(e);
                return new TokenHelper("NULL", "NULL");
            }
        }

        #endregion

        #region Helper Methods

        public static void FillThisAppContext(IThisAppContextInterface context)
        {
            if (context != null)
                _context = context;
        }

        #endregion


    }
}
