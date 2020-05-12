using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class DataBaseConnectionStatus
    {
        #region 
        public bool? IsMainDBConnect { get; set; }
        public Exception MainDBConnectionException { get; set; }
        public bool? IsLogDBConnect { get; set; }
        public Exception LogDbConnectionException { get; set; }

        #endregion

        public DataBaseConnectionStatus()
        {
            MakeDefaults();
        }

        #region Helper Methods

        private void MakeDefaults()
        {
            IsLogDBConnect = null;
            IsMainDBConnect = null;
            MainDBConnectionException = null;
            LogDbConnectionException = null;
        }
        #endregion
    }
}
