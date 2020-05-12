using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums.Business;
using Fhs.Cachless.E_Utility.EnumUtility;

namespace Fhs.Cachless.D_Common.Model
{
    public class AppException:Exception
    {
        #region Variables

        public String Code { get; set; }
        public String TranslateErrorMessage { get; set; }

        #endregion

        public AppException() : base()
        {
            MakeDefaults();
        }

        

        public AppException(string code, string message, string translate) : base(message)
        {
            MakeDefaults();

            Code = code;
            TranslateErrorMessage = translate;
        }
        public AppException(int code, string message, string translate) : base(message)
        {
            MakeDefaults();

            Code = code.ToString();
            TranslateErrorMessage = translate;
        }

        public AppException(int code, string message, string translate, Exception exData = null) : base(message, exData)
        {
            MakeDefaults();

            Code = code.ToString();
            TranslateErrorMessage = translate;
        }
        public AppException(string code, string message, string translate, Exception exData = null) : base(message, exData)
        {
            MakeDefaults();

            Code = code;
            TranslateErrorMessage = translate;
        }

        public AppException(AppErrorsEnum error) : base(error.ToString())
        {
            MakeDefaults();

            Code = ((int)error).ToString();
            TranslateErrorMessage = EnumUtilities.GetEnumDescription(error);
        }
        public AppException(AppErrorsEnum error, Exception exData) : base(error.ToString(), exData)
        {
            MakeDefaults();

            Code = ((int)error).ToString();
            TranslateErrorMessage = EnumUtilities.GetEnumDescription(error);
        }


        #region Helper Methods

        private void MakeDefaults()
        {
            Code = "-1";
            TranslateErrorMessage = "";
        }

        public String ToShortPrint()
        {
            var message = TranslateErrorMessage;
            if (String.IsNullOrWhiteSpace(TranslateErrorMessage) ||
                String.IsNullOrEmpty(TranslateErrorMessage))
                message = Message;

            return String.Format("{0} ({1})", message, Code);
        }


        #endregion
    }
}
