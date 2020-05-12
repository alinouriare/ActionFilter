using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum UserStateEnum
    {
        [EnumDescription("در حال ثبت نام")]
        InRegister = 10,

        [EnumDescription("فعال")]
        Active = 20,

        [EnumDescription("غیر فعال")]
        InActive = 30,

        [EnumDescription("معلق توسط مدیر")]
        BlockByAdmin = 40,

        [EnumDescription("معلق توسط سیستم")]
        BlockBySystem = 50,
    }
}
