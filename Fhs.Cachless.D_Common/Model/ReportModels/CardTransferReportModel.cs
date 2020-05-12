using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.BankUtility;
using Fhs.Cachless.E_Utility.BankUtility.Enums;
using Fhs.Cachless.E_Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model.ReportModels
{
    public class CardTransferReportModel
    {
        #region Variable
        public string BankCode { get; set; }
       
        public String TransactionTypeStr { get; set; }
        public String TransactionStatusStr { get; set; }
        public int TransactionCount { get; set; }
        public decimal TransactionSum { get; set; }

        public string BankName {
            get
            {
                try
                {
                    StdCardModel stdcard = new StdCardModel(BankCode);

                    return stdcard.PersianBankName;
                }
                catch (Exception ex)
                {
                    return "";
                }
              
            }
        }
        //public BankEnum BankEnum
        //{
        //    get
        //    {
        //        try
        //        {
            
        //            return EnumUtilities.ConvertStringToEnum(BankName, BankEnum.Unknwon);
        //        }
        //        catch (Exception ex)
        //        {

        //            return BankEnum.Unknwon;
        //        }
        //    }
        //}
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
        #endregion

        public CardTransferReportModel()
        {
            MakeDefaults();
        }
        #region Helper method
        private void MakeDefaults()
        {
            BankCode = "";
            TransactionTypeStr = "";
            TransactionStatusStr = "";
            TransactionCount = 0;
            TransactionSum = 0;
        }
        #endregion
    }
}
