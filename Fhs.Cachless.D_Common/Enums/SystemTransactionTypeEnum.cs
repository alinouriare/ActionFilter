using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum SystemTransactionTypeEnum
    {
        [EnumDescription("پردازش تستی")]
        TestThread = -1,

        [EnumDescription("غیر استاندارد")]
        NotStandard = 0,

        [EnumDescription("ارسال اعلان")]
        SendNotificaton = 10,

        [EnumDescription("ساخت فایل اکسل")]
        GenerateExcelFile = 20,
    }
}
