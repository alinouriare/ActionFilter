using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum TransactionStatusEnum
    {
        [EnumDescription("در حال انجام")]
        Unknown = 10,

        [EnumDescription("موفق")]
        Success = 20,

        [EnumDescription("شکست خورده")]
        Failed = 30,

        [EnumDescription("عملیات منقضی شده است")]
        Expired=40,

        [EnumDescription("در وضیعت پس از پرداخت")]
        ProcessAfterPayment = 50,

        [EnumDescription("مغایرت")]
        Inconsistent = 60,

        [EnumDescription("رفع مغایرت")]
        FixedInconsistent = 70,
    }
}
