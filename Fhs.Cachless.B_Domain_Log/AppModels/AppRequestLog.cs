using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.C_DataAccess_Log.DBModel;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.SerializDeserializeUtility;

namespace Fhs.Cachless.B_Domain_Log.AppModels
{
    public class AppRequestLog: _BaseAppLogModel
    {
        #region Variables

        public int? Fk_DeviceId { get; set; }
        public int? Fk_TokenId { get; set; }
        public String AppUserInfo
        {
            get { return _appUserInfo; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 100)
                    temp = temp.Substring(0, 100);

                _appUserInfo = temp;
            }
        }
        public String UrlAddress
        {
            get { return _urlAddress; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 300)
                    temp = temp.Substring(0, 300);

                _urlAddress = temp;
            }
        }
        public int StatusCode { get; set; }
        public String StatusCodeStr
        {
            get { return _statusCodeStr; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 50)
                    temp = temp.Substring(0, 50);

                _statusCodeStr = temp;
            }
        }
        public int AnswerCode { get; set; }
        public String AnswerStr
        {
            get { return _answerStr; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 50)
                    temp = temp.Substring(0, 50);

                _answerStr = temp;
            }
        }
        public DateTime RequestDate { get; set; }
        public double ResponseTime { get; set; }
        public String MessageList
        {
            get { return _messageList; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 150)
                    temp = temp.Substring(0, 150);

                _messageList = temp;
            }
        }
        public String MainToken
        {
            get { return _mainToken; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 4000)
                    temp = temp.Substring(0, 4000);

                _mainToken = temp;
            }
        }
        public String ResponseMessage
        {
            get { return _responseMessage; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 4000)
                    temp = temp.Substring(0, 4000);

                _responseMessage = temp;
            }
        }
        public String Ip
        {
            get { return _ip; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 32)
                    temp = temp.Substring(0, 32);

                _ip = temp;
            }
        }
        public String ApplicationOwner
        {
            get { return _applicationOwner; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 50)
                    temp = temp.Substring(0, 50);

                _applicationOwner = temp;
            }
        }
        public String RequestHeader
        {
            get { return _requestHeader; }
            set
            {
                var temp = value ?? "";
                if (temp.Length > 4000)
                    temp = temp.Substring(0, 4000);

                _requestHeader = temp;
            }
        }

        private String _urlAddress = "";
        private String _answerStr = "";
        private String _messageList = "";
        private String _mainToken = "";
        private String _ip = "";
        private String _statusCodeStr = "";
        private String _appUserInfo = "";
        private String _applicationOwner = "";
        private String _responseMessage = "";
        private String _requestHeader = "";
        #endregion

        #region Constructors

        public AppRequestLog() : base(ObjectTypeEnum.AppRequestLog)
        {
            MakeDefaults();
        }
        public AppRequestLog(Object data) : base(ObjectTypeEnum.AppRequestLog, data)
        {
            MakeDefaults();

            if (!(data is AppRequestLogTable)) return;

            var model = (AppRequestLogTable)data;

            Fk_DeviceId = model.Fk_DeviceId;
            AppUserInfo = model.AppUserInfo;
            Fk_TokenId = model.Fk_TokenId;
            UrlAddress = model.UrlAddress;
            StatusCode = model.StatusCode;
            StatusCodeStr = model.StatusCodeStr;
            AnswerCode = model.AnswerCode;
            AnswerStr = model.AnswerStr;
            RequestDate = model.RequestDate;
            ResponseTime = model.ResponseTime;
            MessageList = model.MessageList;
            MainToken = model.MainToken;
            Ip = model.Ip;
            ResponseMessage = model.ResponseMessage;
            ApplicationOwner = model.ApplicationOwner;
            RequestHeader = model.RequestHeader;
        }

        #endregion

        #region Abstract Methods

        protected override object _MakeDAModel()
        {
            var daModel = new AppRequestLogTable()
            {
                Fk_DeviceId = Fk_DeviceId,
                Fk_TokenId = Fk_TokenId,
                AppUserInfo = AppUserInfo,
                UrlAddress = UrlAddress,
                StatusCode = StatusCode,
                StatusCodeStr = StatusCodeStr,
                AnswerCode = AnswerCode,
                AnswerStr = AnswerStr,
                RequestDate = RequestDate,
                ResponseTime = ResponseTime,
                MessageList = MessageList,
                MainToken = MainToken,
                Ip = Ip,
                ResponseMessage = ResponseMessage,
                ApplicationOwner = ApplicationOwner,
                RequestHeader = RequestHeader,
            };
            

            return daModel;
        }
        public override string GetObjectName()
        {
            return UrlAddress + " (" + StatusCode + ") (" + AnswerCode + ")";
        }
        public override string GetObjectDescription()
        {
            return ResponseMessage;
        }

        #endregion

        #region Helper Methods


        private void MakeDefaults()
        {
            Fk_DeviceId = null;
            Fk_TokenId = null;
            AppUserInfo = "";
            UrlAddress = "";
            StatusCode = 0;
            StatusCodeStr = "";
            AnswerCode = 0;
            AnswerStr = "";
            RequestDate = DateTime.MinValue;
            ResponseTime = 0;
            MessageList = "";
            MainToken = "";
            Ip = "";
            ResponseMessage = "";
            ApplicationOwner = "";
            RequestHeader = "";
        }

        #endregion
    }
}
