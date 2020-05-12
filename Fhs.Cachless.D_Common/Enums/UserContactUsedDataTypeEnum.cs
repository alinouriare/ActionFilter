using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum UserContactUsedDataTypeEnum
    {
        [EnumDescription("محل استفاده نامشخص")]
        Null = 0,

        [EnumDescription("در مبدا تراکنش ها استفاده شود")]
        UsedInSource = 10,

        [EnumDescription("در مقصد تراکنش ها استفاده شود")]
        UsedInDestination = 20,

        [EnumDescription("در مبدا و مقصد می تواند استفاده شود")]
        UsedInSourceAndDestination = 30
    }
}
