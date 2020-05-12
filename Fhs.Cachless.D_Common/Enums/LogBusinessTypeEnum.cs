using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum LogBusinessTypeEnum
    {
        [EnumDescription("درون سیستمی")]
        InnerSystemOperaion = -10,
        [EnumDescription("فرآیندهای عمومی")]
        GeneralOperation = 10,
        [EnumDescription("فرآیند لاگین")]
        LoginOperation = 20,
        [EnumDescription("فرآیند فراموشی رمز عبور")]
        ForgetPassword = 30,
        [EnumDescription("فرآیند ثبت نام")]
        RegisterOperation = 40,
        [EnumDescription("فرآیند مالی")]
        FinancialOperation = 50,
        [EnumDescription("خرید بیمه")]
        BuySarmadOperation = 60,

        [EnumDescription("ارسال اس ام اس")]
        SendSms = 70,

        [EnumDescription("فرآیند غیراستاندارد")]
        NotStandardOperation = 1000,
    }
}
