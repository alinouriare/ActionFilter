using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.PublicUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class FinancialTransactionReport
    {
        #region Variables

        public int NumberOfTransaction { get; set; }
        public string TransactionType { get; set; }
        public decimal SumOfTransaction { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    

        #endregion

        public FinancialTransactionReport()
        {
            MakeDefaults();
        }

        #region Helper Methods
        private void MakeDefaults()
        {
            NumberOfTransaction =0;
            TransactionType = "";
            SumOfTransaction =0;
            Year = 0;
            Month = 0;
         
        }

        public override string ToString()
        {
            return null;
        }

        #endregion
    }
}
