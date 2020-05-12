using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum SystemTransactionStatusEnum
    {
        [EnumDescription("ساخته شده")]
        Build = 10,

        [EnumDescription("آماده")]
        Ready = 20,

        [EnumDescription("آغاز")]
        Start = 30,

        [EnumDescription("منتظر")]
        Waiting = 40,
        
        [EnumDescription("لغو توسط مدیر سیستم")]
        TerminateByAdmin = 50,

        [EnumDescription("خاتمه یافته")]
        FailedTerminate = 60,

        [EnumDescription("خاتمه یافته")]
        SuccessTerminate = 70
    }
}
