using Fhs.Cachless.E_Utility.EnumUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum MoeinShopConsistentStatusEnum
    {
        [EnumDescription("رفع مغایرت شده با خرید همان بسته درخواستی مشتری")]
        Consistent = 0,
        [EnumDescription("رفع مغایرت شده با خرید یک بسته جایگزین")]
        ConsistentPackageAlternative = 5,
        [EnumDescription("رفع مغایرت شده با بازگشت پول")]
        ConsistentReturnMoney = 10,
        [EnumDescription("امکان رفع مغایرت وجود ندارد")]
        ConsistentCanNot = 20,
        [EnumDescription("شماره موبایل دیگر ")]
        OtherMobile = 30,
        [EnumDescription("رفع مغایرت شده با خرید یک بسته جایگزین برای شماره موبایل دیگر ")]
        ConsistentPackageAlternativeWithOtherMobile = 35,
        [EnumDescription("ترابرد")]
        Tarabord = 40,
        [EnumDescription("تغییر موبایل و اپراتور")]
        TarabordWithOtherMobile = 45,
    }
}
