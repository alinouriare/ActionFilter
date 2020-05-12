using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using Fhs.Cachless.A_WebUi.App_Classes.Models.ApiResponseModels;
using Fhs.Cachless.B_Domain.AppDomains;
using Fhs.Cachless.B_Domain.AppEnums;
using Fhs.Cachless.B_Domain.AppHelperModels;
using Fhs.Cachless.B_Domain.AppModels;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.E_Utility.BankUtility.Enums;
using Fhs.Cachless.E_Utility.EnumUtility;
using Fhs.Cachless.E_Utility.PublicUtility;
using Fhs.Cachless.E_Utility.SerializDeserializeUtility;

namespace Fhs.Cachless.A_WebUi.App_Classes.HelperClass
{
    public static class ThisAppApi
    {
        public const string UNITOFWORKS_KEYNAME = "UnitOfWorkId";

        public static Guid UnitOfWorkId
        {
            get
            {
                if (HttpContext.Current != null &&
                    HttpContext.Current.Items["MS_HttpRequestMessage"] is HttpRequestMessage &&
                    (HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage).Properties != null &&
                    (HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage).Properties.ContainsKey(
                        UNITOFWORKS_KEYNAME))
                    return
                        (Guid)
                        (HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage).Properties[
                            UNITOFWORKS_KEYNAME];

                return Guid.Empty;
            }
        }

        #region Pubilc Variables

        public static bool IsInDebugeMode
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "DebugeMode", "false");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return flag;
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool IsCSRFActive
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "CSRFControl", "false");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return flag;
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool IsControlCardFromBankDbActive
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "IsControlCardFromBankDBActive",
                        "false");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return flag;
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool? IsSaveAllRequestLogInDB
        {
            get
            {
                try
                {
                    if ((ConfigurationManager.AppSettings["IsSavedAllRequestLog"] ?? "false").ToLower() == "false")
                        return false;
                    return true;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static int MaxNumberOfCSRFToken
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "MaxCSRFTokenCount", "50");
                    var number = 50;
                    int.TryParse(configData, out number);

                    return number;
                }
                catch (Exception ex)
                {
                    return 50;
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

                    return EnumUtilities.ConvertStringToEnum(appModeStr, ApplicationModeEnum.Null);

                }
                catch (Exception ex)
                {
                    return ApplicationModeEnum.Null;
                }
            }
        }

        public static String MabnaTerminalId
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "MabnaTerminalId", "69003378");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return "69003378";
                }
                catch (Exception ex)
                {
                    return "69003378";
                }
            }
        }

        public static String SajamMabnaTerminalId
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "SajamMabnaTerminalId", "61000063");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return "61000063";
                }
                catch (Exception ex)
                {
                    return "61000063";
                }
            }
        }
        public static String SajamMabnaAmount
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "SajamMabnaAmount", "1");
                   

                    return configData;
                }
                catch (Exception ex)
                {
                    return "1";
                }
            }
        }
        public static String MabnaPosSerialNumberId
        {
            get
            {
                try
                {
                    var configData = ThisAppContext.GetSystemConfig("AppSettings", "MabnaPosSerialNumberId", "");
                    var flag = false;
                    bool.TryParse(configData, out flag);

                    return "";
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public static String BaseUrlAddress
        {
            get
            {
                try
                {
                    return ThisAppContext.GetSystemConfig("AppSettings", "ApplicationBaseUrl", "");
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }
        
        public const int MAX_APP_CONFIG_CACHE = 900; //15 min - مدت زمانی که کانفیگ برنامه کش شود
        public static readonly int MaxTimeToReSentConfirmation = 1;
        public static readonly int MaxTryToShowCaptcha = 3;
        public static readonly bool ShowOnlyNumbersInCaptcha = true;
        public static readonly double MinTimeToUpdateUserExpireLoginTime = 1;
        public static readonly double MaxTimeToUserNotWorkingInSystem = 15; //24 Hour

        public static readonly String UserLoginSessionName = "UserLoginSession";
        public static readonly String UserLoginTimeSessionName = "UserLoginTimeSession";

        public static readonly String UserDataCacheOnRamKeyName = "UserDataCacheOnRamKeyName";

        #endregion

        #region Application Name

        public static String ApplicationName
        {
            get { return "Saap Application"; }
        }

        public static String ApplicationVersion
        {
            get { return "1.0.0"; }
        }

        public static String ApplicationTitle
        {
            get { return "صاپ"; }
        }

        public static String ApplicationOwner
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["ApplicationOwner"]??"N/A";
                }
                catch (Exception)
                {
                    return "N/A";
                }
            }
        }

        #endregion

        #region Business Access

        public static readonly String LockApplicationSettingsObj = "LockApplicationSettingsObj";
        public static readonly String LockApplicationSetUserAccessObj = "LockApplicationSetUserAccessObj";
        private static readonly String _innerLockApplicatinSettingsObj = "InnerLockApplicatinSettingsObj";
        private static readonly String _applicatinServiceConfigName = "ApplicatinServiceConfigName";

        private static AppServiceStatusHolder _defaultAppServiceStatusHolder = null;

        public static AppServiceStatusHolder GetAppServiceStatusHolder()
        {
            try
            {
                if (_defaultAppServiceStatusHolder == null)
                {
                    Exception exData = null;
                    _defaultAppServiceStatusHolder = AppServiceStatusHolder.InstallModel(out exData);
                }

                var serviceStatusInDb = GetSystemConfig(ConfigGroupEnum.AppServiceSettings, _applicatinServiceConfigName,
                    (AppServiceStatusHolder) null);

                if (serviceStatusInDb == null)
                {
                    var configData = new ConfigData()
                    {
                        ConfigUsedType = ConfigUsedTypeEnum.SystemConfigGroup,
                        ConfigGroupCode = ConfigGroupEnum.AppServiceSettings,
                        ConfigName = _applicatinServiceConfigName,
                        ConfigValue = _defaultAppServiceStatusHolder,
                    };
                    SetSystemConfig(configData);

                    return _defaultAppServiceStatusHolder;
                }

                return serviceStatusInDb;
            }
            catch (Exception ex)
            {
                AddException(ex);

                return AppServiceStatusHolder.InstallModel();
            }
        }

        public static bool IsServiceAccessForThisBank(CoreServiceTypeEnum service, BankEnum bankCode)
        {
            try
            {
                if (_defaultAppServiceStatusHolder == null)
                {
                    Exception exData = null;
                    _defaultAppServiceStatusHolder = AppServiceStatusHolder.InstallModel(out exData);
                }

                var appServiceStatusHolder = GetAppServiceStatusHolder();


                return appServiceStatusHolder.HasServiceInBank(bankCode, service);

            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }

        public static bool IsServicesAccessForThisOperator(CoreServiceTypeEnum service,
            MobileOperatorTypeEnum operatorType)
        {
            try
            {
                if (_defaultAppServiceStatusHolder == null)
                {
                    Exception exData = null;
                    _defaultAppServiceStatusHolder = AppServiceStatusHolder.InstallModel(out exData);
                }

                var appServiceStatusHolder = GetAppServiceStatusHolder();


                return appServiceStatusHolder.HasServiceInMobileOperator(operatorType, service);

            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }

        public static bool IsServicesAccessForThisOperator(CoreServiceTypeEnum service, string phoneNumber)
        {
            try
            {
                if (_defaultAppServiceStatusHolder == null)
                {
                    Exception exData = null;
                    _defaultAppServiceStatusHolder = AppServiceStatusHolder.InstallModel(out exData);
                }

                var appServiceStatusHolder = GetAppServiceStatusHolder();

                if (String.IsNullOrWhiteSpace(phoneNumber) ||
                    String.IsNullOrEmpty(phoneNumber)) return false;

                phoneNumber = PublicUtilities.CleanIranMobilePhoneNumber(phoneNumber);
                var operatorType = PublicUtilities.GetPhoneNumberOperator(phoneNumber, true);
                var operatorTypeStr = operatorType.ToString().Split('_')[0].ToLower();
                var mainOperatorType = EnumUtilities.ConvertStringToEnum(operatorTypeStr, MobileOperatorTypeEnum.Null);

                return appServiceStatusHolder.HasServiceInMobileOperator(mainOperatorType, service);

            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }

        public static bool IsIndependeServicesAccess(CoreServiceTypeEnum service)
        {
            try
            {
                if (_defaultAppServiceStatusHolder == null)
                {
                    Exception exData = null;
                    _defaultAppServiceStatusHolder = AppServiceStatusHolder.InstallModel(out exData);
                }

                var appServiceStatusHolder = GetAppServiceStatusHolder();


                return appServiceStatusHolder.HasIndependService(service);

            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }

        public static bool SaveAppServiceStatusHolder(AppServiceStatusHolder data)
        {
            try
            {
                if (data == null) return false;

                lock (_innerLockApplicatinSettingsObj)
                {
                    var configData = new ConfigData()
                    {
                        ConfigUsedType = ConfigUsedTypeEnum.SystemConfigGroup,
                        ConfigGroupCode = ConfigGroupEnum.AppServiceSettings,
                        ConfigName = _applicatinServiceConfigName,
                        ConfigValue = data,
                    };
                    SetSystemConfig(configData);
                }

                return true;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }

        #endregion

        #region Api Token Handling

        public static int MaxJwtTokenExpireTime = 2880; //48Hour

        public static bool IsApiTokenValid
        {
            get
            {
                if (String.IsNullOrEmpty(TokenMainId) ||
                    String.IsNullOrWhiteSpace(TokenMainId) ||
                    ApiTokenData == null)
                    return false;
                return true;
            }
        }

        public static String TokenMainId
        {
            get
            {
                try
                {
                    var deviceidentity = (ClaimsIdentity) HttpContext.Current.User.Identity;
                    var tokenDataHolder = deviceidentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                    return tokenDataHolder?.Value ?? "";

                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public static WebApiToken ApiTokenData
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(TokenMainId) ||
                        String.IsNullOrWhiteSpace(TokenMainId)) return null;

                    if (_webApiTokenData != null &&
                        _webApiTokenData.TokenId == TokenMainId &&
                        Math.Abs((_webApiTokenCachTime - DateTime.Now).TotalSeconds) < 5)
                        return _webApiTokenData;

                    #region Find Api Token Data


                    if (!String.IsNullOrEmpty(TokenMainId) &&
                        !String.IsNullOrWhiteSpace(TokenMainId))
                    {
                        var item = WebApiTokenRoot.GetWebApiTokenRootByTokenId(TokenMainId);
                        if (item != null)
                        {
                            _webApiTokenData = item?.RootData;
                            _webApiTokenCachTime = DateTime.Now;
                            return item?.RootData;
                        }
                    }

                    #endregion

                    return null;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public static bool? CheckCsrfToken(string csrfToken, out Exception exData)
        {
            exData = null;
            try
            {
                // در صورتی که نیاز به تنظیمات CSRF نباشد
                if (!IsCSRFActive) return true;

                if (!IsApiTokenValid) return false;

                var rootItem = new WebApiTokenRoot(_webApiTokenData);
                var result = rootItem.ValidateCSRFTokenAndAccept(csrfToken, out exData);
                _webApiTokenData = rootItem.RootData;

                return result;
            }
            catch (Exception ex)
            {
                exData = ex;
                return null;
            }
        }

        public static bool? GenerateNewCsrfToken(out Exception exData)
        {
            exData = null;
            try
            {
                if (!IsApiTokenValid) return false;

                var rootItem = new WebApiTokenRoot(_webApiTokenData);
                var result = rootItem.GenerateNewCsrfToken(out exData,MaxNumberOfCSRFToken);
                _webApiTokenData = rootItem.RootData;

                return result;
            }
            catch (Exception ex)
            {
                exData = ex;
                return null;
            }
        }

        private static WebApiToken _webApiTokenData = null;
        private static DateTime _webApiTokenCachTime = DateTime.MinValue;

        #endregion

        #region UserManagement

        public static String RequestClientIP
        {
            get
            {
                try
                {
                    var request = HttpContext.Current?.Request;
                    if (request == null) return "";

                    if (request.Headers != null &&
                        request.Headers["CLIENT-IP"] != null)
                    {
                        return request.Headers["CLIENT-IP"];
                    }


                    var szRemoteAddr = request.UserHostAddress;
                    var szXForwardedFor = request.Headers["X-Forwarded-For"];
                    var szIP = "";

                    if (szXForwardedFor == null)
                        szIP = szRemoteAddr;
                    else
                    {
                        szIP = szXForwardedFor;
                        if (szIP != null && szIP.IndexOf(",") > 0)
                        {
                            var arIPs = szIP.Split(',');
                            foreach (string item in arIPs)
                                if (!_isPrivateIP(item))
                                    return item;
                        }
                    }
                    return szIP ?? "";
                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return "";
                }
            }
        }

        public static IdentifyClass CurrnetUserIdentify
        {
            get
            {
                try
                {
                    Object identifyStr = null;
                    Object dateTimeStr = null;

                    #region Load From Ram Cach Memory

                    Object cachRam_IdentifyStr = _getOnRamCache(UserLoginSessionName);
                    Object cachRam_DateTimeStr = _getOnRamCache(UserLoginTimeSessionName);
                    if (cachRam_IdentifyStr != null && cachRam_DateTimeStr != null)
                    {
                        identifyStr = cachRam_IdentifyStr;
                        dateTimeStr = cachRam_DateTimeStr;
                    }
                    else
                    {
                        identifyStr = GetSessionApi(UserLoginSessionName);
                        _setOnRamCach(UserLoginSessionName, identifyStr);

                        dateTimeStr = GetSessionApi(UserLoginTimeSessionName);
                        _setOnRamCach(UserLoginTimeSessionName, dateTimeStr);

                    }

                    #endregion

                    var lastConnectTime = DateTime.MinValue;

                    #region Get Last User Login 

                    if (dateTimeStr == null)
                        return null;
                    else if (dateTimeStr is String && !DateTime.TryParse(dateTimeStr.ToString(), out lastConnectTime))
                        return null;
                    else if (!(dateTimeStr is DateTime))
                        return null;
                    else
                        lastConnectTime = (DateTime) dateTimeStr;

                    #endregion

                    if (Math.Abs((DateTime.Now - lastConnectTime).TotalMinutes) > MaxTimeToUserNotWorkingInSystem)
                        return null;
                    else if (Math.Abs((DateTime.Now - lastConnectTime).TotalMinutes) >= MinTimeToUpdateUserExpireLoginTime &&
                             Math.Abs((DateTime.Now - lastConnectTime).TotalMinutes) <= MaxTimeToUserNotWorkingInSystem)
                    {
                        dateTimeStr = DateTime.Now;
                        SetSessionApi(UserLoginTimeSessionName, dateTimeStr);

                        _setOnRamCach(UserLoginTimeSessionName, dateTimeStr);
                    }

                    #region Get Identify Data

                    if (identifyStr != null &&
                        identifyStr is String)
                    {
                        var identify = new IdentifyClass(identifyStr.ToString());

                        if (!identify.IsEmpty)
                            return identify;
                    }
                    else if (identifyStr != null &&
                             identifyStr is IdentifyClass)
                        return (IdentifyClass) identifyStr;

                    #endregion

                    return null;
                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return null;
                }
            }
        }

        public static UserData CurrentUser
        {
            get
            {
                try
                {
                    //اگر در کش رم هست و زیر 1 دقیقه است که کش شده است برگردانش
                    var cacheRamUserData = _getOnRamCache(UserDataCacheOnRamKeyName, (UserData) null, false, 120);

                    if (CurrnetUserIdentify == null ||
                        CurrnetUserIdentify.IsEmpty ||
                        CurrnetUserIdentify.DataId == 0) return null;

                    if (cacheRamUserData == null ||
                        cacheRamUserData.Id != CurrnetUserIdentify.DataId)
                    {
                        cacheRamUserData = UserDataRoot.GetDataById(CurrnetUserIdentify.DataId);

                        if (cacheRamUserData != null)
                            _setOnRamCach(UserDataCacheOnRamKeyName, cacheRamUserData);
                    }

                    return cacheRamUserData;
                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return null;
                }
            }
        }

        public static RoleData UserRoleData
        {
            get { return CurrentUser?.UserRoleData; }
        }

        public static UserRoleTypeEnum UserRole
        {
            get
            {
                if (UserRoleData != null) return UserRoleData.RoleName;

                return UserRoleTypeEnum.Guest;
            }
        }

        public static List<IPDataRule> CurrentClientIPRule
        {
            get
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(RequestClientIP) ||
                        String.IsNullOrEmpty(RequestClientIP))
                        return new List<IPDataRule>();

                    if (_ipDataRuleList == null ||
                        Math.Abs((DateTime.Now - _ipDataRuleCachTime).Seconds) > 15)
                    {
                        _ipDataRuleList = IPDataRuleRoot.GetIPDataRuleByIPValueAndExpireTime(RequestClientIP,
                            DateTime.Now);
                        _ipDataRuleCachTime = DateTime.Now;
                    }

                    return _ipDataRuleList;
                }
                catch (Exception ex)
                {
                    AddException(ex);
                    return new List<IPDataRule>();
                }
            }
        }

        public static void IncrementIPDataRuleForCurrentIP(RuleTypeEnum ruleType, int expireLenghtMin)
        {
            try
            {
                /*var ipDataRoot = IPDataRoot.FindIPData(RequestClientIP);

                if (ipDataRoot == null || ipDataRoot.RootData == null)
                    throw new Exception("سامانه امکان ذخیره سازی IP کاربر در سامانه را ندارد!");/**/

                var ipDataRule = IPDataRuleRoot.FindIPDataRuleByIPDataValueAndRuleType(RequestClientIP, ruleType);
                if (!ipDataRule.IsActive)
                    ipDataRule.RuleDetails = new RuleDetailsModel();

                ipDataRule.RuleDetails.MaxTry++;
                ipDataRule.RuleExpireTime = DateTime.Now.AddMinutes(expireLenghtMin);
                
                var dataRoot = new IPDataRuleRoot(ipDataRule);
                var dataStatus = dataRoot.Save();

                if (dataStatus.Status != OperationStatusEnum.Success)
                    throw new Exception("سامانه قادر به ذخیره سازی قانون بر روی IP درخواست نمی باشد!");

            }
            catch (Exception ex)
            {
                AddException(ex);
            }
        }

        public static IPDataRule GetIPDataRuleForCurrentIP(RuleTypeEnum ipDataRule)
        {
            try
            {
                return IPDataRuleRoot.FindIPDataRuleByIPDataValueAndRuleType(RequestClientIP, ipDataRule);

            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }
        }


        public static Object GetSessionApi(string keyName, bool isCleanData = false)
        {
            try
            {
                if (!IsApiTokenValid) return null;

                var rootData = new WebApiTokenRoot(ApiTokenData);

                var dataSearch = rootData.GetSessionData(keyName, isCleanData);

                if (dataSearch != null)
                    return dataSearch.KeyValue;

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T GetSessionApi<T>(string keyName, T defaultValue, bool isCleanData = false)
        {
            try
            {
                if (!IsApiTokenValid) return defaultValue;

                var rootData = new WebApiTokenRoot(ApiTokenData);

                var dataSearch = rootData.GetSessionData(keyName, isCleanData);

                if (dataSearch != null && (dataSearch.KeyValue is T))
                    return (T) dataSearch.KeyValue;

                return defaultValue;
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }

        public static bool SetSessionApi(string keyName, Object keyValue)
        {
            try
            {
                if (!IsApiTokenValid) return false;

                var rootData = new WebApiTokenRoot(ApiTokenData);

                return rootData.SetSessionData(keyName, keyValue);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CleanSessionByName(string keyName, bool ifCleanOperationFailedMakeException = true)
        {
            try
            {
                if (!IsApiTokenValid) return false;

                var rootData = new WebApiTokenRoot(ApiTokenData);

                return rootData.CleanSessionByName(keyName);

            }
            catch (Exception ex)
            {
                if (ifCleanOperationFailedMakeException)
                    throw ex;
                return false;
            }
        }

        public static bool CleanAllSessions(bool ifCleanOperationFailedMakeException = true)
        {
            try
            {
                if (!IsApiTokenValid) return false;

                var rootData = new WebApiTokenRoot(ApiTokenData);

                return rootData.CleanAllSessionData();

            }
            catch (Exception ex)
            {
                if (ifCleanOperationFailedMakeException)
                    throw ex;
                return false;
            }
        }

        //private static UserData _userData = null;
        //private static DateTime _userDataCachTime = DateTime.MinValue;
        private static List<IPDataRule> _ipDataRuleList = new List<IPDataRule>();
        private static DateTime _ipDataRuleCachTime = DateTime.MinValue;




        #endregion

        #region Cach On Server's Ram Mechanism


        private static Dictionary<string, Object> _webApiSessionCacheDic = new Dictionary<string, object>();
        private static Dictionary<string, DateTime> _webApiSessionCacheFlagDic = new Dictionary<string, DateTime>();

        private static Object _getOnRamCache(string keyName, bool isCleanFromRamCach = false,
            int validTotalSecToCach = 30)
        {
            try
            {
                var tokenMainId = TokenMainId;

                if (String.IsNullOrWhiteSpace(tokenMainId) || String.IsNullOrEmpty(tokenMainId))
                    return null;

                var cachRamKeyName = TokenMainId + "_" + keyName;
                var flagRamKeyName = TokenMainId + "_" + keyName + "_CacheTime";

                if (!_webApiSessionCacheFlagDic.ContainsKey(flagRamKeyName) ||
                    !_webApiSessionCacheDic.ContainsKey(cachRamKeyName) ||
                    Math.Abs((DateTime.Now - _webApiSessionCacheFlagDic[flagRamKeyName]).TotalSeconds) >
                    validTotalSecToCach)
                    return null;

                var result = _webApiSessionCacheDic[cachRamKeyName];

                if (isCleanFromRamCach)
                {
                    _webApiSessionCacheFlagDic.Remove(flagRamKeyName);
                    _webApiSessionCacheDic.Remove(cachRamKeyName);
                }

                return result;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }
        }

        private static T _getOnRamCache<T>(string keyName, T defaultValue, bool isCleanFromRamCach = false,
            int validTotalSecToCach = 30)
        {
            try
            {
                var tokenMainId = TokenMainId;

                if (String.IsNullOrWhiteSpace(tokenMainId) || String.IsNullOrEmpty(tokenMainId))
                    return defaultValue;

                var cachRamKeyName = TokenMainId + "_" + keyName;
                var flagRamKeyName = TokenMainId + "_" + keyName + "_CacheTime";

                if (_webApiSessionCacheFlagDic.ContainsKey(flagRamKeyName))
                {
                    var testTimer = Math.Abs((DateTime.Now - _webApiSessionCacheFlagDic[flagRamKeyName]).TotalSeconds);
                }


                if (!_webApiSessionCacheFlagDic.ContainsKey(flagRamKeyName) ||
                    !_webApiSessionCacheDic.ContainsKey(cachRamKeyName) ||
                    !(_webApiSessionCacheDic[cachRamKeyName] is T) ||
                    Math.Abs((DateTime.Now - _webApiSessionCacheFlagDic[flagRamKeyName]).TotalSeconds) >
                    validTotalSecToCach)
                    return defaultValue;

                var result = (T) _webApiSessionCacheDic[cachRamKeyName];

                if (isCleanFromRamCach)
                {
                    _webApiSessionCacheFlagDic.Remove(flagRamKeyName);
                    _webApiSessionCacheDic.Remove(cachRamKeyName);
                }

                return result;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return defaultValue;
            }
        }

        private static void _setOnRamCach(string keyName, Object keyValue)
        {
            try
            {
                var tokenMainId = TokenMainId;

                if (String.IsNullOrWhiteSpace(tokenMainId) ||
                    String.IsNullOrEmpty(tokenMainId))
                    return;

                var cachTime = DateTime.Now;
                var cachRamKeyName = TokenMainId + "_" + keyName;
                var flagRamKeyName = TokenMainId + "_" + keyName + "_CacheTime";

                if (!_webApiSessionCacheDic.ContainsKey(cachRamKeyName))
                    _webApiSessionCacheDic.Add(cachRamKeyName, keyValue);
                else
                    _webApiSessionCacheDic[cachRamKeyName] = keyValue;


                if (!_webApiSessionCacheFlagDic.ContainsKey(flagRamKeyName))
                    _webApiSessionCacheFlagDic.Add(flagRamKeyName, cachTime);
                else
                    _webApiSessionCacheFlagDic[flagRamKeyName] = cachTime;

            }
            catch (Exception ex)
            {
                AddException(ex);
            }
        }

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

        #region Configuration Management

        private static ConfigurationManagement _configManagement = new ConfigurationManagement();

        public static void ReloadConfig()
        {
            try
            {
                _configManagement = new ConfigurationManagement();
            }
            catch (Exception e)
            {
                AddException(e);
            }
        }

        public static void CleanCacheConfig()
        {
            try
            {
                if (_configManagement != null)
                    _configManagement.CleanCacheData();
            }
            catch (Exception e)
            {
                AddException(e);
            }
        }

        public static List<ConfigData> GetSystemConfig(ConfigGroupEnum groupName)
        {
            return GetSystemConfig(groupName.ToString());
        }
        public static List<ConfigData> GetSystemConfig(string groupName)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetSystemConfigByGroupName(groupName);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
            }
        }
        public static ConfigData GetSystemConfig(ConfigGroupEnum groupName, string name)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetSystemConfig(groupName, name);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }

        }
        public static ConfigData GetSystemConfig(string groupName, string name)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetSystemConfig(groupName, name);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }
        }
        public static T GetSystemConfig<T>(ConfigGroupEnum groupName, string name, T defaultValue)
        {
            try
            {
                if (_configManagement == null)
                    return defaultValue;
                return _configManagement.GetSystemConfig(groupName, name, defaultValue);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return defaultValue;
            }
        }
        public static T GetSystemConfig<T>(string groupName, string name, T defaultValue)
        {
            try
            {
                if (_configManagement == null)
                    return defaultValue;
                return _configManagement.GetSystemConfig(groupName, name, defaultValue);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return defaultValue;
            }
        }

        public static ConfigData SetSystemConfig(ConfigData data)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.SetSystemConfig(data);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
            }
        }
        public static ConfigData SetSystemConfig<T>(ConfigGroupEnum groupCode, string name, T value)
        {
            try
            {
                if (_configManagement == null)
                    return null;

                var data = new ConfigData()
                {
                    ConfigUsedType = ConfigUsedTypeEnum.SystemConfigGroup,
                    ConfigGroupCode = groupCode,
                    ConfigGroupName = groupCode.ToString(),
                    ConfigName = name,
                    ConfigValue = value,
                };

                return _configManagement.SetSystemConfig(data);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
            }
        }
        public static ConfigData SetSystemConfig<T>(string groupCodeStr, string name, T value)
        {
            try
            {
                if (_configManagement == null)
                    return null;

                var groupCode = EnumUtilities.ConvertStringToEnum(groupCodeStr, ConfigGroupEnum.NotStandard);
                var data = new ConfigData()
                {
                    ConfigUsedType = ConfigUsedTypeEnum.SystemConfigGroup,
                    ConfigGroupCode = groupCode,
                    ConfigGroupName = groupCodeStr,
                    ConfigName = name,
                    ConfigValue = value,
                };

                return _configManagement.SetSystemConfig(data);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
            }
        }


        public static List<ConfigData> GetUserConfig(IdentifyClass userIdentify, ConfigGroupEnum groupName)
        {
            return GetUserConfig(userIdentify, groupName.ToString());
        }
        public static List<ConfigData> GetUserConfig(IdentifyClass userIdentify, string groupName)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetUserConfigByGroupName(userIdentify, groupName);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
            }
        }
        public static ConfigData GetUserConfig(IdentifyClass userIdentify, ConfigGroupEnum groupName, string name)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetUserConfig(userIdentify, groupName, name);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }

        }
        public static ConfigData GetUserConfig(IdentifyClass userIdentify, string groupName, string name)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.GetUserConfig(userIdentify, groupName, name);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }
        }

        public static T GetUserConfig<T>(IdentifyClass userIdentify, ConfigGroupEnum groupName, string name,
            T defaultValue)
        {
            try
            {
                if (_configManagement == null)
                    return defaultValue;
                return _configManagement.GetUserConfig(userIdentify, groupName, name, defaultValue);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return defaultValue;
            }
        }

        public static T GetUserConfig<T>(IdentifyClass userIdentify, string groupName, string name, T defaultValue)
        {
            try
            {
                if (_configManagement == null)
                    return defaultValue;
                return _configManagement.GetUserConfig(userIdentify, groupName, name, defaultValue);
            }
            catch (Exception ex)
            {
                AddException(ex);
                return defaultValue;
            }
        }
        public static ConfigData SetUserConfig(IdentifyClass userIdentify, ConfigData data)
        {
            try
            {
                if (_configManagement == null)
                    return null;
                return _configManagement.SetUserConfig(userIdentify, data);
            }
            catch (Exception e)
            {
                AddException(e);
                return null;
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
                    AddInformationLogInDataBase(new InformationLog(exData), ThisAppApi.CurrnetUserIdentify);

            }
            catch (Exception ex)
            {
                _exceptionDataList.Add(ex);
            }
        }


        #endregion

        #region Application Log Handling

        public static bool AddInformationLogInDataBase(InformationLog data, IdentifyClass userId = null,IdentifyClass dataId = null)
        {
            try
            {
                LogUserData logData = new LogUserData(data, dataId, userId);
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