using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class KeyValueItem
    {
        #region Variables
        public String Key { get; set; }
        public Object Value { get; set; }

        #endregion

        public KeyValueItem()
        {
            MakeDefaults();
        }

        #region Helper Methods

        private void MakeDefaults()
        {
            Key = "";
            Value = "";
        }

        #endregion
    }
}
