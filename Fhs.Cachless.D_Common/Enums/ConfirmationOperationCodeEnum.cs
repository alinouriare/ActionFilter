using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ConfirmationOperationCodeEnum
    {
        [EnumDescription("نامشخص")]
        Null = 0,

        [EnumDescription("تاییدیه ثبت نام")]
        UserRegisterConfirmation = 10,

        [EnumDescription("تاییدیه فراموشی رمز عبور")]
        ForgottenPasswordConfirmation = 20,

        [EnumDescription("تاییدیه کارت جدید")]
        NewSaderatCartUsedConfirmation = 30,

        [EnumDescription("تایید انتقال وجه کشاورزی")]
        KeshavarziCardToCardTransfer = 40,

    }
}
