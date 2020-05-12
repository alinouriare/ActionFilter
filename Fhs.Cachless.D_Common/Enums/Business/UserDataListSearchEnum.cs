using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum UserDataListSearchEnum
    {
        [EnumDescription("همه موارد")]
        All = 10,

        [EnumDescription("نام کاربری")]
        UserName = 20,

        [EnumDescription("نام و نام خانوادگی")]
        UserNickName = 30,

        [EnumDescription("شماره تلفن")]
        PhoneNumber = 40,

        [EnumDescription("شماره کارت")]
        CartNumber = 50,

        [EnumDescription("شناسه داده")]
        Id = 100,

        [EnumDescription("شناسه یکتا داده")]
        ObjectId = 110,
    }
}
