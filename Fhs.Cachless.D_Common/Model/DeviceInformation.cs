using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class DeviceInformation
    {
        #region Variables

        public String DeviceModel { get; set; }
        public String Manufacturer { get; set; }
        public String DeviceCode { get; set; }
        #endregion

        public DeviceInformation()
        {
            MakeDefaults();
        }

        #region Helper Methods
        private void MakeDefaults()
        {
            DeviceModel = "";
            Manufacturer = "";
            DeviceCode = "";
        }

        public override string ToString()
        {
            return String.Format("Model:{0} - Manufacture:{1} - Code:{2} ", DeviceModel, Manufacturer, DeviceCode);
        }

        #endregion
    }
}
