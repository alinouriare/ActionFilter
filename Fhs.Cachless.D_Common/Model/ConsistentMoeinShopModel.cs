using Fhs.Cachless.D_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class ConsistentMoeinShopModel
    {
        #region Variables

        public string ConsistentId { get; set; }
        public int SappId { get; set; }
        public int MoenId { get; set; }
        public string PhoneNumber { get; set; }
        public MoeinShopConsistentStatusEnum ConsistentStatusType
        {
            get
            {
                if (ConsistentStatusId>=0)
                    return (MoeinShopConsistentStatusEnum)ConsistentStatusId;
                return MoeinShopConsistentStatusEnum.ConsistentCanNot;
            }
        }
        public int ConsistentStatusId { get; set; }
        public string StatusDescription { get; set; }
        public string BankReturnPaymentCode { get; set; }
        public string AlternativePackageCode { get; set; }

        private int? _consistentStatusId = 0;
        #endregion

        public ConsistentMoeinShopModel()
        {
            MakeDefaults();
        }

        #region Helper Methods
        private void MakeDefaults()
        {
            ConsistentId = string.Empty;
            ConsistentStatusId = 0;
            SappId = 0;
            MoenId = 0;
            PhoneNumber = string.Empty;
            StatusDescription = string.Empty;
            BankReturnPaymentCode = null;
            AlternativePackageCode = null;
            //ConsistentStatusType = MoeinShopConsistentStatusEnum.ConsistentCanNot;
        }


        #endregion
    }
}
