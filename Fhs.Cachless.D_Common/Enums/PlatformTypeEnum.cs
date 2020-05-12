using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum PlatformTypeEnum
    {
        Null = 0,

        [EnumDescription("پیامکی")]
        SmsPlatform = 10,

        [EnumDescription("پست الکترونیک")]
        EmailPlatform = 20,

        [EnumDescription("موبایل")]
        MobileNotificationPlatform = 30,

        [EnumDescription("وب")]
        WebNotificationPlatform = 40,

        [EnumDescription("پنل مدیریتی")]
        WebAdminPanelNotificationPlatform = 50,
    }
}
