using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum NotificationDataTargetListSearchEnum
    {
        [EnumDescription("همه")]
        All = 10,

        [EnumDescription("شماره تلفن")]
        PhoneNumber = 20,

        [EnumDescription("نام کاربری")]
        UserName = 30,

        [EnumDescription("شناسه داده")]
        Id = 100,

        [EnumDescription("شناسه یکتا داده")]
        ObjectId = 110,
    }
}
