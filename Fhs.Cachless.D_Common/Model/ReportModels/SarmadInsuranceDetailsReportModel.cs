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
    public class SarmadInsuranceDetailsReportModel
    {
        #region Variable
        public string SarmadInsuranceCode { get; set; }
        public String TransactionTypeStr { get; set; }
        public TransactionTypeEnum TransactionType
        {
            get
            {
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

        public String TransactionStatusStr { get; set; }
        public TransactionStatusEnum TransactionStatus
        {
            get
            {

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
        public int TransactionCount { get; set; }
        public decimal TransactionSum { get; set; }
        
        #endregion

        public SarmadInsuranceDetailsReportModel()
        {
            MakeDefaults();
        }
        #region Helper method
        private void MakeDefaults()
        {
            SarmadInsuranceCode = "";
            TransactionTypeStr = "";
            TransactionStatusStr = "";
            TransactionCount = 0;
            TransactionSum = 0;
        }
        #endregion
    }
}
