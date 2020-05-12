using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.BankUtility;
using Fhs.Cachless.E_Utility.BankUtility.Enums;
using Fhs.Cachless.E_Utility.EnumUtility;
using Fhs.Cachless.E_Utility.PublicUtility;
using Fhs.Cachless.E_Utility.PublicUtility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Fhs.Cachless.D_Common.Model.ReportModels
{
    public class BillNumberDetailsReportModel
    {
        #region Variable

        public string BillCode { get; set; }
        //public string BillNumber { get; set; }
       // private BillEnum _BillType = BillEnum.NotSet;
        public BillEnum BillType {
            get
            {
                try
                {
                    return _findBillType();
                    //if (_BillType == BillEnum.NotSet)
                    //{
                    //    StdBillModel modelBill = new StdBillModel(BillGetInformationTypeEnum.BillNumberOnly, BillNumber);
                    //    return modelBill.BillType;
                    //}
                    //else
                    //   return _BillType;
                }
                catch (Exception ex)
                {

                    return BillEnum.NotSet;
                }
            }
        }
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
        public decimal TransactionValue { get; set; }
       


        private BillEnum _findBillType()
        {
            try
            {
                int billCode = 0;
                if (String.IsNullOrEmpty(BillCode) ||
                  String.IsNullOrWhiteSpace(BillCode) ||
                  !int.TryParse(BillCode, out billCode))
                    return BillEnum.NotSet;

                    switch (billCode)
                {
                    case 0:
                        return BillEnum.None;
                    case 1:
                        return BillEnum.WaterDepartment;
                    case 2:
                        return BillEnum.PowerDepartment;
                    case 3:
                        return BillEnum.GasDepartment;
                    case 4:
                        return BillEnum.Telecommunications;
                    case 5:
                        return BillEnum.Mci;
                    case 6:
                        return BillEnum.TaxMunicipality;
                    case 7:
                        return BillEnum.None;
                    case 8:
                        return BillEnum.TaxOrganization;
                    case 9:
                        return BillEnum.DrivingFine;
                }
                return BillEnum.None;

            }
            catch (Exception e)
            {
                return BillEnum.None;
            }
        }

        #endregion

        public BillNumberDetailsReportModel()
        {
            MakeDefaults();
        }
        //public BillNumberDetailsReportModel(string billNumber)
        //{
        //    MakeDefaults();
        //    StdBillModel modelBill = new StdBillModel(BillGetInformationTypeEnum.BillNumberOnly, billNumber);
        //    _BillType=modelBill.BillType;
        //}
        #region Helper method
        private void MakeDefaults()
        {
            // BillType = BillEnum.NotSet;
            BillCode = "";
            TransactionTypeStr = "";
            TransactionStatusStr = "";
            TransactionCount = 0;
            TransactionSum = 0;
            TransactionValue = 0;
         //   BillNumber = "";
        }

        //public static Expression<Func<BillNumberDetailsReportModel,BillEnum>> FunctionBillType(string billNumber)
        //{
        //    if(string.IsNullOrEmpty(billNumber) && 
        //        string.IsNullOrWhiteSpace(billNumber))
        //    {

        //    StdBillModel modelBill = new StdBillModel(BillGetInformationTypeEnum.BillNumberOnly, billNumber);
        //    return p => modelBill.BillType;

        //    }

        //    return p=> BillEnum.NotSet;
        //}
        #endregion


    }
}
