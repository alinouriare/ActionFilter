using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum NotificationDataStateEnum
    {
        [EnumDescription("نامشخص")]
        Null = 0,

        [EnumDescription("چرک نویس")]
        Draft = 10,

        [EnumDescription("در حال ارسال")]
        Sending = 20,

        [EnumDescription("ارسال شده")]
        Sent = 30,
    }
}
