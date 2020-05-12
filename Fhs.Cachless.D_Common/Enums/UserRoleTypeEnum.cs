using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum UserRoleTypeEnum
    {
        [EnumDescription("اشتباه در ساخت گروه")]
        Null = -1000,

        [EnumDescription("عمومی")]
        AllUsers = -20,
        [EnumDescription("کاربران وارد شده")]
        AllLoginedUsers = -10,
        [EnumDescription("کاربر مهمان")]
        Guest = 0,
        [EnumDescription("کاربران موبایل")]
        ApiUser = 10,

        [EnumDescription("کاربر با دسترسی محدود")]
        WebReporterUser = 15,

        [EnumDescription("کاربران مدیر سیستم")]
        WebAdmin = 20,
        [EnumDescription("کاربران مدیر ارشد سیستم")]
        WebSuperAdmin = 30
    }
}
