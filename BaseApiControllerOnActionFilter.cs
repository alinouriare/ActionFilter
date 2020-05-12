using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Fhs.Cachless.A_WebUi.App_Classes.Enums;
using Fhs.Cachless.A_WebUi.App_Classes.Models.ApiResponseModels;
using Fhs.Cachless.B_Domain.AppDomains;
using Fhs.Cachless.B_Domain.AppEnums;
using Fhs.Cachless.B_Domain_Log.AppDomains;
using Fhs.Cachless.B_Domain_Log.AppModels;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.PublicUtility;
using Fhs.Cachless.E_Utility.SerializDeserializeUtility;

namespace Fhs.Cachless.A_WebUi.App_Classes.HelperClass.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BaseApiControllerOnActionFilter: ActionFilterAttribute
    {
        private Guid _apiUnitOfWorksId = Guid.Empty;
        private DateTime _requestDateTime = DateTime.Now;
        private String _mainToken = "";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _apiUnitOfWorksId = Guid.NewGuid();
            actionContext.Request.Properties.Add("IsAddInDB", false);

            _requestDateTime = DateTime.Now;
            actionContext.Request.Properties.Add(ThisAppApi.UNITOFWORKS_KEYNAME, _apiUnitOfWorksId);

            #region Get Main Token

            var request = actionContext.Request;
            var authorization = request.Headers.Authorization;
            if (authorization != null && authorization.Scheme == "Bearer" &&
                !string.IsNullOrEmpty(authorization.Parameter))
                _mainToken = authorization.Parameter;

            #endregion

            if (ThisAppApi.CurrentApplicationMode != ApplicationModeEnum.WebApiMode)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "Access Denied",
                    Content = new ObjectContent<BaseResponse<String>>(new BaseResponse<string>(ServerAnswerEnum.AccessDenied), new JsonMediaTypeFormatter(), "application/json"),
                    RequestMessage = actionContext.Request,
                };
                return;
            }
            else if (actionContext != null && 
                     actionContext.Request != null &&
                     IsThisUrlHasBug(actionContext.Request.RequestUri.LocalPath))
            {
                var result = ImproveBusinessRuleAndBugs(ref actionContext);
                if (result == true)
                    return;
            }
            
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                #region Save Request Log in DB
                if (ThisAppApi.IsSaveAllRequestLogInDB == true)
                {
                    var responseMessageTask = actionExecutedContext.Response.Content.ReadAsStringAsync();
                    var urlAddress = actionExecutedContext.Request.RequestUri.LocalPath;
                    var status = actionExecutedContext.Response.StatusCode;
                    var statusStr = actionExecutedContext.Response.StatusCode.ToString();
                    var responseMessage = responseMessageTask.Result;
                    
                    var tokenId = ThisAppApi.ApiTokenData?.Id ?? (int?)null;
                    var deviceId = ThisAppApi.ApiTokenData?.Fk_DeviceId ?? (int?) null;
                    var responseTime = (DateTime.Now - _requestDateTime).TotalMilliseconds;
                    var appUserName = ThisAppApi.CurrentUser?.Username ?? "";
                    var ip = ThisAppApi.RequestClientIP;
                    var applicationOwner = ThisAppApi.ApplicationOwner;
                    var requestHeader = SerializUtilities.JsonSerialize(PrintAllRequestHeaders(actionExecutedContext));

                    Exception exData = null;
                    var publicData = (BaseResponseLogger)SerializUtilities.JsonDeSerialize(responseMessage, typeof(BaseResponseLogger), out exData);
                    var answerStr = "";
                    var answerCode = 0;
                    var messageList = "";
                    if (exData == null && publicData != null)
                    {
                        answerStr = publicData.Answer;
                        answerCode = publicData.AnswerCode;
                        messageList = SerializUtilities.JsonSerialize(publicData.MessageList);
                    }

                    _BaseLogApp.AddAppRequestLog(
                        new AppRequestLog()
                        {
                            ObjectId = ThisAppApi.UnitOfWorkId,
                            Fk_DeviceId = deviceId,
                            Fk_TokenId = tokenId,
                            AppUserInfo = appUserName,
                            UrlAddress = urlAddress,
                            StatusCode = (int)status,
                            StatusCodeStr = statusStr,
                            AnswerCode = answerCode,
                            AnswerStr = answerStr,
                            RequestDate = _requestDateTime,
                            ResponseTime = responseTime,
                            MessageList = messageList,
                            MainToken = _mainToken,
                            Ip = ip,
                            ResponseMessage = responseMessage,
                            ApplicationOwner = applicationOwner,
                            RequestHeader = requestHeader,
                        }
                    );
                }
                #endregion
            }
            catch (Exception ex)
            {
                
            }

            //base.OnActionExecuted(actionExecutedContext);
        }

        #region Helper Methods

        private bool? ImproveBusinessRuleAndBugs(ref HttpActionContext actionContext)
        {
            try
            {
                if (actionContext != null &&
                     actionContext.Request != null &&
                     actionContext.Request.RequestUri != null &&
                     actionContext.Request.RequestUri.LocalPath.ToLower() == "/api/v1/card/initcardtransfer".ToLower())
                {
                    #region Remove bug of 'api/v1/card/initcardtransfer' in IOS v  1.08.02 and LESS

                    if (ThisAppApi.ApiTokenData == null ||
                        ThisAppApi.ApiTokenData.DeviceData == null)
                        return false;

                    if (ThisAppApi.ApiTokenData.DeviceData.PlatFormCode == ClientPlatFormCoreEnum.IOS)
                    {
                        if (GetApplicationVersionNumberInHeader(actionContext) == 10802)
                        {
                            var iosUrl = ThisAppApi.GetSystemConfig(ConfigGroupEnum.AppSettings, AppSettingsNameEnum.iOsDownloadLink.ToString(), "/Download/ios_sepehrcard_bsi_vip");
                            
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                ReasonPhrase = "OK",
                                Content = new ObjectContent<BaseResponse<RedirectResponse>>(new BaseResponse<RedirectResponse>(ServerAnswerEnum.Redirect,new RedirectResponse("کاربر گرامی؛برای استفاده از سرویس کارت به کارت لطفاً برنامه خود را بروزرسانی کنید", iosUrl)), new JsonMediaTypeFormatter(), "application/json"),
                                RequestMessage = actionContext.Request,
                            };
                            return true;
                        }
                        else if (GetApplicationVersionNumberInHeader(actionContext) < 10802)
                        {
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                ReasonPhrase = "OK",
                                Content = new ObjectContent<BaseResponse<string>>(new BaseResponse<string>(new Exception("کاربر گرامی؛برای استفاده از سرویس کارت به کارت لطفاً برنامه خود را بروزرسانی کنید")), new JsonMediaTypeFormatter(), "application/json"),
                                RequestMessage = actionContext.Request,
                            };
                            return true;
                        }
                    }
                    #endregion
                }

                return false;
            }
            catch (Exception ex)
            {
                ThisAppApi.AddException(ex);
                return null;
            }
        }

        private bool IsThisUrlHasBug(string url)
        {
            if (String.IsNullOrEmpty(url) ||
                String.IsNullOrWhiteSpace(url)) return false;

            /*if (url.ToLower() == "/api/v1/card/initcardtransfer".ToLower())
                return true;/**/
            return false;
        }

        public String GetApplicationVersionInHeader(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext == null ||
                    actionContext.Request == null ||
                    actionContext.Request.Headers == null) return "";

                var header = actionContext.Request.Headers;
                if (!header.Contains("version"))
                    return "NULL";

                var result = "";
                var index = 0;
                foreach (var str in header.GetValues("version"))
                {
                    result = (index > 0 ? ";" : "");
                    result += str;
                }
                return result;
            }
            catch (Exception ex)
            {
                ThisAppApi.AddException(ex);
                return "";
            }
        }
        public int GetApplicationVersionNumberInHeader(HttpActionContext actionContext)
        {
            try
            {
                var versionCode = 0;
                if (int.TryParse(GetApplicationVersionInHeader(actionContext).Replace(".",""), out versionCode))
                    return versionCode;

                return 0;
            }
            catch (Exception ex)
            {
                ThisAppApi.AddException(ex);
                return 0;
            }
        }

        private List<KeyValuePair<string, string>> PrintAllRequestHeaders(HttpActionExecutedContext actionContext)
        {
            var result = new List<KeyValuePair<string, string>>();
            try
            {
                if (actionContext == null || 
                    actionContext.Request == null || 
                    actionContext.Request.Headers == null ||
                    actionContext.Request.Headers.Count() == 0)
                    return result;

                foreach (var itemKeyValue in actionContext.Request.Headers)
                {
                    var key = itemKeyValue.Key;
                    var valueStr = "";
                    foreach (var str in itemKeyValue.Value)
                        valueStr += "("+str+")";

                    result.Add(new KeyValuePair<string, string>(key, valueStr));
                }
                
            }
            catch (Exception e)
            {
                result.Add(new KeyValuePair<string, string>("Error",e.ToString()));    
            }

            return result;
        }
        #endregion
    }
}