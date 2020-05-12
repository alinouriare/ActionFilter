using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ConfirmationTypeEnum
    {
        Null = 0,
        [EnumDescription("پیامک")]
        SMSType = 10,

        [EnumDescription("پست الکترونیک")]
        EmailType = 20,
    }
}
