using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.EnumUtility;
using Fhs.Cachless.E_Utility.PublicUtility;
using Fhs.Cachless.E_Utility.PublicUtility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fhs.Cachless.D_Common.Model.ReportModels
{
    public class ChargeBuyDetailsReportModel
    {
        #region Variable
        public string PhoneOperatorCode { get; set; }
        public String TransactionTypeStr { get; set; }
        public String TransactionStatusStr { get; set; }
        public int TransactionCount { get; set; }
        public decimal TransactionSum { get; set; }
        public TransactionTypeEnum TransactionType
        {
            get
            {
                //رشته
                //TransactionTypeStr
                // رو به اینام
                // TransactionTypeEnum
                //تبدیل کنید
                try
                {
                    return EnumUtilities.ConvertStringToEnum(TransactionTypeStr, TransactionTypeEnum.Null);
                }
                catch (Exception ex)
                {

                    return TransactionTypeEnum.Null;
                }

            }
        }

        public TransactionStatusEnum TransactionStatus
        {
            get
            {
                //رشته
                //TransactionStatusStr
                // رو به اینام
                // TransactionStatusEnum
                //تبدیل کنید
                try
                {
                    return EnumUtilities.ConvertStringToEnum(TransactionStatusStr, TransactionStatusEnum.Unknown);
                }
                catch (Exception ex)
                {

                    return TransactionStatusEnum.Unknown;
                }

            }
        }

        public PhoneOperatorTypeEnum OperatorType
        {
            get { return PublicUtilities.GetPhoneNumberOperator(PhoneOperatorCode+"0000000", true); }
        }

        public ChargeTypeEnum ChargeType
        {
            get
            {
                try
                {

                    if (!OperatorType.ToString().Contains("_")) return ChargeTypeEnum.Null;

                    var operatorStr = OperatorType.ToString().Split('_')[0].ToLower();
                    if (operatorStr == "mtn")
                        return ChargeTypeEnum.Mtn;
                    else if (operatorStr == "mci")
                        return ChargeTypeEnum.Mci;
                    else if (operatorStr == "raytel")
                        return ChargeTypeEnum.Raytel;

                    return ChargeTypeEnum.Null;
                }
                catch (Exception ex)
                {
                    return ChargeTypeEnum.Null;
                }
            }
        }

        #endregion

        public ChargeBuyDetailsReportModel()
        {
            MakeDefaults();
        }
        #region Helper method
        private void MakeDefaults()
        {
            PhoneOperatorCode = "";
            TransactionTypeStr = "";
            TransactionStatusStr = "";
            TransactionCount = 0;
            TransactionSum = 0;
        }
        #endregion
    }
}
