using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class FinancialOperationModel
    {
        #region Variables

        public int CountNumber { get; set; }
        public decimal OperationValue { get; set; }

        #endregion

        public FinancialOperationModel()
        {
            MakeDefaults();
        }
        public FinancialOperationModel(int count,decimal optValue)
        {
            MakeDefaults();

            CountNumber = count;
            OperationValue = optValue;
        }

        #region Helper Methods

        private void MakeDefaults()
        {
            CountNumber = 0;
            OperationValue = 0;
        }

        #endregion
    }
}
