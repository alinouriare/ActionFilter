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
    public class SPFinancialTransactionErrorListGroupByTTypeTStatusModel
    {
        #region Variable
        public string SourceSub { get; set; }

        public String TransactionType { get; set; }
        public String TransactionStatus { get; set; }
        public string FaultCode { get; set; }
        public string FaultErrorMessage { get; set; }
        public int CountError { get; set; }
        public string BankName
        {
            get
            {
                try
                {
                    StdCardModel stdcard = new StdCardModel(SourceSub);

                    return stdcard.PersianBankName;
                }
                catch (Exception ex)
                {
                    return "";
                }

            }
        }
        public BankEnum BankNameEnum
        {
            get
            {
                try
                {
                    StdCardModel stdcard = new StdCardModel(SourceSub);

                    return stdcard.BankEnum;
                }
                catch (Exception ex)
                {
                    return BankEnum.Unknwon;
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
        public TransactionTypeEnum EnumTransactionType
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
                    return EnumUtilities.ConvertStringToEnum(TransactionType, TransactionTypeEnum.Null);
                }
                catch (Exception ex)
                {

                    return TransactionTypeEnum.Null;
                }

            }
        }

        public TransactionStatusEnum EnumTransactionStatus
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
                    return EnumUtilities.ConvertStringToEnum(TransactionStatus, TransactionStatusEnum.Unknown);
                }
                catch (Exception ex)
                {

                    return TransactionStatusEnum.Unknown;
                }

            }
        }
        #endregion

        public SPFinancialTransactionErrorListGroupByTTypeTStatusModel()
        {
            MakeDefaults();
        }
        #region Helper method
        private void MakeDefaults()
        {
            SourceSub = "";
            TransactionType= "";
            TransactionStatus = "";
            FaultCode = "";
            FaultErrorMessage = "";
            CountError = 0;
        }
        #endregion

    }
}
