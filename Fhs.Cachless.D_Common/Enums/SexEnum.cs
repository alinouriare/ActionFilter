using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum SexEnum
    {
        [EnumDescription("-")]
        Null = 0,

        [EnumDescription("مرد")]
        Male = 10,

        [EnumDescription("زن")]
        Female = 20
    }
}
