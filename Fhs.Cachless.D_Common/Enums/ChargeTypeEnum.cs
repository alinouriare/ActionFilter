using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ChargeTypeEnum
    {
        [EnumDescription("-")]
        Null = 0,
        [EnumDescription("ایرانسل")]
        Mtn = 0335,
        [EnumDescription("همراه اول")]
        Mci = 0334,
        [EnumDescription("رایتل")]
        Raytel = 0336,
        //[EnumDescription("اپراتور تالیا")]
        //Taliya= 0932,
        //[EnumDescription("اسپادان")]
        //Spadan = 0931,
        //[EnumDescription("شبکه مستقل تلفن همراه کیش")]
        //TKC= 0934,
    }
}
