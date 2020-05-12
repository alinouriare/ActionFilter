using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum UserContactSavedTypeEnum
    {
        [EnumDescription("به صورت خودکار اضافه شده است")]
        AutoAddToList = 10,

        [EnumDescription("کاربر به سیستم اضافه کرده است")]
        UserAddToList = 20,
    }
}
