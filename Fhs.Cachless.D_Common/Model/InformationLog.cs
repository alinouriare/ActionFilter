using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Enums.Business;
using Fhs.Cachless.E_Utility.PublicUtility;

namespace Fhs.Cachless.D_Common.Model
{
    public class InformationLog
    {
        #region Variables

        public InformationLogTypeEnum LogType { get; set; }

        public String PersianLogType
        {
            get { return GetPersianInformationLogTypeEnum(LogType); }
        }
        public String Group { get; set; }
        public string Code { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String AdditionalData { get; set; }
        public DateTime LogDate { get; set; }
        
        public string IconBootstrap
        {
            get
            {
                switch (LogType)
                {
                    case InformationLogTypeEnum.Error:
                        return "fa-close";
                    case InformationLogTypeEnum.Information:
                        return "fa-info";
                    case InformationLogTypeEnum.Exception:
                        return "fa-minus-square";
                    case InformationLogTypeEnum.Warning:
                        return "fa-warning";
                }

                return "";
            }
        }

        public static String GeneralGroupName = "General";
        public static String Seprator = "_#!!#_";

        #endregion

        #region Constructors

        public InformationLog()
        {
            MakeDefault();
        }

        public InformationLog(string title, string description)
        {
            MakeDefault();

            Title = title;
            Description = description;
        }
        public InformationLog(string code, string title, string description)
        {
            MakeDefault();

            Code = code;
            Title = title;
            Description = description;
        }

        public InformationLog(InformationLogTypeEnum type, string title, string description = "")
        {
            MakeDefault();

            LogType = type;
            Title = title;
            Description = description;
        }
        public InformationLog(InformationLogTypeEnum type, string code, string title, string description = "")
        {
            MakeDefault();

            LogType = type;
            Code = code;
            Title = title;
            Description = description;
        }


        public InformationLog(string group, string code, string title, string description)
        {
            MakeDefault();

            Group = group;
            Code = code;
            Title = title;
            Description = description;
        }
        public InformationLog(InformationLogTypeEnum type, string group, string code, string title, string description)
        {
            MakeDefault();

            LogType = type;
            Group = group;
            Code = code;
            Title = title;
            Description = description;
        }

        public InformationLog(InformationLogTypeEnum type, string group, string code, string title, string description, string additionalData)
        {
            MakeDefault();

            LogType = type;
            Group = group;
            Code = code;
            Title = title;
            Description = description;
            AdditionalData = additionalData;
        }

        public InformationLog(InformationLogTypeEnum type, string group, string title, string description, string additionalData, DateTime date)
        {
            MakeDefault();

            LogType = type;
            Group = group;
            Title = title;
            Description = description;
            AdditionalData = additionalData;
            LogDate = date;

        }
        public InformationLog(InformationLogTypeEnum type, string group, string code, string title, string description, string additionalData, DateTime date)
        {
            MakeDefault();

            LogType = type;
            Group = group;
            Code = code;
            Title = title;
            Description = description;
            AdditionalData = additionalData;
            LogDate = date;

        }

        public InformationLog(Exception ex, String additionalData = "")
        {
            try
            {
                MakeDefault();

                if (ex == null) return;

                LogType = InformationLogTypeEnum.Exception;
                Group = ex.GetType().FullName;
                Code = "0";
                Title = ex.Message;
                Description = "";
                AdditionalData = ex.ToString() + "\n:::" + additionalData;
            }
            catch (Exception e)
            {
                AdditionalData = e.ToString() + "\n:::" + additionalData;
            }


        }
        public InformationLog(AppException ex, String additionalData = "")
        {
            try
            {
                MakeDefault();

                if (ex == null) return;

                LogType = InformationLogTypeEnum.AppException;
                Group = ex.GetType().FullName;
                Code = ex.Code;
                Title = ex.Message;
                Description = ex.TranslateErrorMessage;
                AdditionalData = ex.ToString() + "\n:::" + additionalData;
            }
            catch (Exception e)
            {
                AdditionalData = e.ToString() + "\n:::" + additionalData;
            }


        }
        public InformationLog(AppErrorsEnum errorCode, String additionalData = "")
        {
            try
            {
                MakeDefault();

                var ex = new AppException(errorCode);

                LogType = InformationLogTypeEnum.AppException;
                Group = ex.GetType().FullName;
                Code = ex.Code;
                Title = ex.Message;
                Description = ex.TranslateErrorMessage;
                AdditionalData = ex.ToString() + "\n:::" + additionalData;
            }
            catch (Exception e)
            {
                AdditionalData = e.ToString() + "\n:::" + additionalData;
            }
        }

        public InformationLog(string strLog)
        {
            try
            {
                MakeDefault();

                var arrayStr = strLog.Split(new string[] { Seprator }, StringSplitOptions.None);

                if (arrayStr.Length == 1)
                {
                    LogType = InformationLogTypeEnum.Information;
                    Title = arrayStr[0];
                    return;
                }

                var type = InformationLogTypeEnum.Information;
                if (arrayStr.Length > 0 && Enum.TryParse(arrayStr[0], out type))
                    LogType = type;


                if (arrayStr.Length > 1)
                    Group = arrayStr[1];

                if (arrayStr.Length > 2)
                    Title = arrayStr[2];

                if (arrayStr.Length > 3)
                    Description = arrayStr[3];

                if (arrayStr.Length > 4)
                    AdditionalData = arrayStr[4];

                var date = DateTime.Now;
                if (arrayStr.Length > 5 && DateTime.TryParse(arrayStr[5], out date))
                    LogDate = date;

                if (arrayStr.Length > 6)
                    Code = arrayStr[6];

            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region Helper Methods

        private void MakeDefault()
        {
            LogType = InformationLogTypeEnum.Information;
            Group = GeneralGroupName;
            Code = "-10000";
            Title = "";
            Description = "";
            AdditionalData = "";
            LogDate = DateTime.Now;
        }

        public override string ToString()
        {
            return PrintShort(true);
        }

        public string PrintShort(bool ShowCode)
        {
            var prefixCode = "";
            if (LogType == InformationLogTypeEnum.AppException)
            {
                #region Handling AppException
                if (!String.IsNullOrWhiteSpace(Description) && !String.IsNullOrEmpty(Description))
                    prefixCode = Description;
                else if (!String.IsNullOrWhiteSpace(Title) && !String.IsNullOrEmpty(Title))
                    prefixCode = Title;

                
                if (ShowCode && !String.IsNullOrWhiteSpace(Code) && !String.IsNullOrEmpty(Code))
                    prefixCode += " (" + Code + ")";
                return prefixCode;
                #endregion
            }
            
            if (!String.IsNullOrWhiteSpace(Code) && !String.IsNullOrEmpty(Code))
                prefixCode = Code + ":::";

            if (!String.IsNullOrWhiteSpace(Description) &&
                !String.IsNullOrEmpty(Description))
                return prefixCode + Title + ":::" + Description;

            return prefixCode + Title;
        }
        public string PrintLong()
        {
            return String.Format("{0} {1}{2} - {3}",
                                    PersianLogType,
                                    Title,
                                    (Description != "" ? ": " + Description : ""),
                                    PublicUtilities.ConvertDateTimeToJalali(LogDate) + " " + LogDate.ToString("HH:mm:ss"));
        }

        public string SerializeObject()
        {
            return String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", Seprator, LogType, Group, Title, Description, AdditionalData, LogDate, Code);
        }
        public static String GetPersianInformationLogTypeEnum(InformationLogTypeEnum logType)
        {
            try
            {
                switch (logType)
                {
                    case InformationLogTypeEnum.Information:
                        return "خبر";
                    case InformationLogTypeEnum.Warning:
                        return "هشدار";
                    case InformationLogTypeEnum.Error:
                        return "خطا";
                    case InformationLogTypeEnum.Exception:
                        return "خطای بحرانی";
                    default:
                        return "نامشخص";
                }
            }
            catch (Exception e)
            {
                return "نامشخص";
            }
        }


        #endregion
    }
}