using System;
using System.Collections.Generic;
using System.Linq;
using Fhs.Cachless.A_WebUi.App_Classes.Enums;
using Fhs.Cachless.B_Domain.AppHelperModels;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.E_Utility.EnumUtility;
using Newtonsoft.Json;

namespace Fhs.Cachless.A_WebUi.App_Classes.Models.ApiResponseModels
{
    public class BaseResponse<T>
    {
        #region Variables

        [JsonIgnore]
        public ServerAnswerEnum ServerAnswer { get; set; }

        public String Answer
        {
            get { return ServerAnswer.ToString(); }
        }
        public int AnswerCode
        {
            get { return (int) ServerAnswer; }
        }
        public String PersianAnswerCode
        {
            get { return GetServerAnswerEnumByType(ServerAnswer); }
        }
        
        public T Data { get; set; }
        public Object AdditionalData { get; set; }
        public List<String> MessageList { get; set; }

        #endregion

        #region Constructors

        public BaseResponse()
        {
            MakeDefaults();
        }

        public BaseResponse(WebCoreException ex)
        {
            MakeDefaults();

            ServerAnswer = ServerAnswerEnum.WebCoreException;
            MessageList.Add(ex != null ? ex.Message : "خطای نامشخص");
        }
        public BaseResponse(AppException ex)
        {
            MakeDefaults();

            ServerAnswer = ServerAnswerEnum.Exception;
            MessageList.Add(ex != null ? ex.ToShortPrint() : "خطای نامشخص");
        }
        public BaseResponse(Exception ex)
        {
            MakeDefaults();

            ServerAnswer = ServerAnswerEnum.Exception;
            MessageList.Add(ex != null ? ex.Message : "خطای نامشخص");
        }
        public BaseResponse(ServerAnswerEnum answer, T data = default(T), Object additionalData = null, List<String> messagelist = null)
        {
            MakeDefaults();

            ServerAnswer = answer;
            Data = data;
            AdditionalData = additionalData;
            if (messagelist != null)
                MessageList = messagelist;
        }
        public BaseResponse(ServerAnswerEnum answer, List<String> messagelist)
        {
            MakeDefaults();

            ServerAnswer = answer;

            if (MessageList != null)
                MessageList = messagelist;
        }
        public BaseResponse(ServerAnswerEnum answer, List<Exception> messagelist)
        {
            MakeDefaults();

            ServerAnswer = answer;

            if (MessageList != null)
                MessageList = messagelist.Select(x=>x.Message).ToList();
        }
        public BaseResponse(ServerAnswerEnum answer, List<InformationLog> messagelist)
        {
            MakeDefaults();

            ServerAnswer = answer;

            if (MessageList != null)
                MessageList = messagelist.Select(x => x.PrintShort(true)).ToList();
        }
        #endregion

        #region Methods
        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            ServerAnswer = ServerAnswerEnum.Null;
            Data = default(T);
            AdditionalData = "";
            MessageList = new List<string>();
        }
        private static String GetServerAnswerEnumByType(ServerAnswerEnum type)
        {
            try
            {
                return EnumUtilities.GetEnumDescription(type);
            }
            catch (Exception e)
            {
                return "نامشخص";
            }
        }
        public void AddMessage(string message)
        {
            if(MessageList == null)
                MessageList = new List<string>();

            MessageList.Add(message);
        }

       
        #endregion
    }

    public class BaseResponseLogger
    {
        public String Answer { get; set; }
        public int AnswerCode { get; set; }
        public String PersianAnswerCode { get; set; }
        public List<String> MessageList { get; set; }
    }
}