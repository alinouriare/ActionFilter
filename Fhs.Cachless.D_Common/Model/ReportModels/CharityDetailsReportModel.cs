using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model.ReportModels
{
    public class CharityDetailsReportModel
    {
        #region Variable
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String BillOrganizationCode { get; set; }
        public bool IsActive { get; set; }
        #endregion

        public CharityDetailsReportModel()
        {
            MakeDefaults();
        }
        #region Helper method
        private void MakeDefaults()
        {
            Id = Guid.Empty;
            Title = "";
            BillOrganizationCode = "";
            IsActive = false;
        }
        #endregion
    }
}
