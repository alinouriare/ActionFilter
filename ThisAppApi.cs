using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Fhs.Cachless.B_Domain.AppDomains;
using Fhs.Cachless.B_Domain.AppEnums;
using Fhs.Cachless.B_Domain.AppHelperModels;
using Fhs.Cachless.B_Domain.AppModels;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.E_Utility.BankUtility.Enums;
using Fhs.Cachless.E_Utility.PublicUtility;

namespace Fhs.Cachless.A_SecureWebUi.App_Classes.HelperClass
{
    public static class ThisAppApi
    {
        #region Pubilc Variables

        public static String EncryptKey01
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "EncryptKey01", "");

                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }

        public static String EncryptKey02
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "EncryptKey02", "");

                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }
        public static String SecureMode
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "SecureMode", "Encrypt");

                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }
        public static String MainAppUrlAddress
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "MainAppUrlAddress", "");

                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }
        public static String MainSecureAppUrlAddress
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "MainSecureAppUrlAddress", "");

                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }

        

        public static ApplicationModeEnum CurrentApplicationMode
        {
            get
            {
                try
                {
                    var appModeStr = ThisAppContext.GetSystemConfig("AppSettings", "ApplicationMode",
                        ApplicationModeEnum.Null.ToString());
                    var appMode = ApplicationModeEnum.Null;

                    if (Enum.TryParse(appModeStr, out appMode))
                        return appMode;

                    return ApplicationModeEnum.Null;
                }
                catch (Exception ex)
                {
                    return ApplicationModeEnum.Null;
                }
            }
        }


        private static List<String> _isNotSecureUrlList = new List<string>()
        {
            /*"/api/v1/device/register",
            "/api/v1/device/gettoken",/**/
        };

        #endregion

        #region File Management

        public static string GetApplicationBaseRoot()
        {
            try
            {

                return HttpContext.Current.Server.MapPath("/");
            }
            catch (Exception ex)
            {
                return _applicationBaseRoot;
            }

        }
        public static string GetApplicationConfigBaseRoot()
        {
            try
            {
                return GetApplicationBaseRoot() + "/App_Files/Config";
            }
            catch (Exception ex)
            {
                return _applicationBaseRoot + "/App_Files/Config";
            }
        }
        public static string GetApplicationLogFileRoot()
        {
            try
            {
                return GetApplicationBaseRoot() + "/App_Files/Logs";
            }
            catch (Exception ex)
            {
                return "/App_Files/Logs";
            }
        }

        #endregion

        #region Exception Handling

        public static List<Exception> _exceptionDataList = new List<Exception>();

        public static void AddException(Exception exData, bool savedInDB = true)
        {
            try
            {
                if (_exceptionDataList == null)
                    _exceptionDataList = new List<Exception>();

                _exceptionDataList.Add(exData);

                if (savedInDB)
                    AddInformationLogInDataBase(new InformationLog(exData));

            }
            catch (Exception ex)
            {
                _exceptionDataList.Add(ex);
            }
        }


        #endregion

        #region Application Log Handling

        public static bool AddInformationLogInDataBase(InformationLog data, IdentifyClass userId = null, IdentifyClass dataId = null)
        {
            try
            {
                LogUserData logData = new LogUserData( data, dataId, userId);
                LogUserDataRoot logDataRoot = new LogUserDataRoot(logData);
                var res = logDataRoot.Save();
                if (res.Status == OperationStatusEnum.Failed) return false;
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    AddInformationLogInFile(new InformationLog(ex));
                    AddInformationLogInFile(data, userId, dataId);
                    return false;
                }
                catch (Exception ex2)
                {
                    return false;
                }
            }
        }

        public static bool AddInformationLogInFile(InformationLog data, IdentifyClass userId = null, IdentifyClass dataId = null)
        {
            try
            {
                if (data == null) return false;

                if (!Directory.Exists(GetApplicationLogFileRoot())) return false;

                var fileAddress = GetApplicationLogFileRoot() + "/" + GetLogFileName() + ".MCMSLog";

                var message = "";
                message += "UserId : " + (userId?.ToString() ?? "NULL") + Environment.NewLine;
                message += "dataId : " + (dataId?.ToString() ?? "NULL") + Environment.NewLine;
                message += "----------------- Message Header -----------------------" + Environment.NewLine;
                message += data.PrintLong() + Environment.NewLine;
                message += "----------------- Message  Body  -----------------------" + Environment.NewLine;
                message += "->->-> " + data.SerializeObject().Replace(InformationLog.Seprator, "." + Environment.NewLine + "->->-> ") + Environment.NewLine;
                message += "----------------- End Of Message  ----------------------" + Environment.NewLine;

                using (var writer = new StreamWriter(fileAddress, true))
                {
                    writer.Write(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region Helper Methods

        public static bool IsEncryptRequests()
        {
            //IsEncryptWeb
            try
            {
                var isEncryptedUrl = false;
                if (bool.TryParse(ThisAppContext.GetSystemConfig("AppSettings", "IsEncryptRequests", "true"),
                    out isEncryptedUrl))
                    return isEncryptedUrl;

                return true;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return true;
            }
        }
        public static bool IsUrlInEncryptList(string urlAddress)
        {
            try
            {
                if (_isNotSecureUrlList.Any(x => x.Trim().ToLower() == urlAddress.Trim().ToLower()))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return true;
            }
        }

        private static bool _isPrivateIP(string ip)
        {
            return false;
        }

        public static void SetAppilcationBaseRoot(string applicationBaseRoot)
        {
            _applicationBaseRoot = applicationBaseRoot;
        }
        private static String _applicationBaseRoot = "";

        public static String GetCurrentTime()
        {
            try
            {
                var dateStr = PublicUtilities.ConvertDateTimeTo8CharacterJalali(DateTime.Now);


                return dateStr + DateTime.Now.ToString("HHmmss") + "_" + DateTime.Now.Millisecond.ToString("0000");
            }
            catch (Exception ex)
            {
                AddException(ex);
                return DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + "_" + DateTime.Now.Millisecond.ToString("0000");
            }
        }
        public static string GetLogFileName()
        {
            return "LogFile_" + GetCurrentTime() + "_" + Guid.NewGuid().ToString().Replace("-", "");
        }

        #endregion


    }
}