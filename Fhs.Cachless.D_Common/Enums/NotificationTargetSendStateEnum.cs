using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum NotificationTargetSendStateEnum
    {
        [EnumDescription("نامشخص")]
        Null = 10,

        [EnumDescription("فرستاده")]
        Sending = 10,

        [EnumDescription("ارسال موفق")]
        SentSuccess = 10,

        [EnumDescription("ارسال شکست خورده")]
        SentFailed = 20,

    }
}
