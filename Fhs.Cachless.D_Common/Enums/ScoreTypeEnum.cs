using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ScoreTypeEnum
    {
        [EnumDescription("-")]
        Null = 0,

        [EnumDescription("دعوت از دوستان")]
        InvitedFriend = 10,

        [EnumDescription("کارت به کارت")]
        CardToCard = 20,

        [EnumDescription("ثبت نام کننده")]
        UserRegistered= 30,

        [EnumDescription("تکمیل پروفایل")]
        ProfileComplete = 40,

        [EnumDescription("امتیاز مصرف شده")]
        Consume = 200
    }
}
