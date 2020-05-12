using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum NotificationDataListSearchEnum
    {
        [EnumDescription("همه موارد")]
        All = 10,

        [EnumDescription("عنوان اعلان")]
        Title = 20,

        [EnumDescription("توضیحات اعلان")]
        Description = 30,

        [EnumDescription("نام کاربر سازنده")]
        CreateUserName = 40,

        [EnumDescription("نام کاربر بروزرسان")]
        LastUdateUserName = 50,
        
        [EnumDescription("شناسه داده")]
        Id = 100,

        [EnumDescription("شناسه یکتا داده")]
        ObjectId = 110,
    }
}
