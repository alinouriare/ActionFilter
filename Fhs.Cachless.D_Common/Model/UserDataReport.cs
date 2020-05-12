using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.PublicUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class UserDataReport
    {
        #region Variables

       public int Number { get; set; }
     //   public int SumOfUser { get; set; }
        public  DateTime? DateReport { get; set; }
        public string PersianDate {
            get
            {
                try
                {
                    return DateReport != null ? PublicUtilities.ConvertDateTimeToJalali(DateReport??DateTime.MinValue) : "";
                }
                catch (Exception ex)
                {
                   
                    return "نامشخص";
                }
            }
        }

        #endregion

        public UserDataReport()
        {
            MakeDefaults();
        }

        #region Helper Methods
        private void MakeDefaults()
        {
            Number = 0;
            // SumOfUser = 0;
            DateReport = DateTime.Now;
           
        }

        public override string ToString()
        {
            return null;
        }

        #endregion
    }
}
