using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ConfigUsedTypeEnum
    {
        [EnumDescription("غیراستاندارد")]
        NotStandardConfig = 0,

        [EnumDescription("گروه تنظیمات سیستمی")]
        SystemConfigGroup = 10,

        [EnumDescription("گروه مرتبط با کاربر")]
        UserConfigGroup = 20,
    }
}
