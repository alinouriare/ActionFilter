using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum NotificationReceiveStatusEnum
    {
        [EnumDescription("در حال ارسال")]
        Null = 0,
        [EnumDescription("ارسال شده")]
        Sent = 10,
        [EnumDescription("دریافت شده")]
        Received = 20,
        [EnumDescription("مشاهده شده")]
        Seen = 30,
        
    }
}
