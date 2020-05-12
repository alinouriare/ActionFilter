using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class LogUserIpReportModel
    {
        #region Variables
        public int UserId { get; set; }
        public DateTime LogCreateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        #endregion

        public LogUserIpReportModel()
        {
            MakeDefaults();
        }
        public LogUserIpReportModel(int count,decimal optValue)
        {
            MakeDefaults();

        }

        #region Helper Methods

        private void MakeDefaults()
        {
    
            LogCreateTime = DateTime.Now;
            Title = "";
            Description = "";
        }

        #endregion
    }
}
