using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum AppDeviceInfoListSearchEnum
    {
        [EnumDescription("همه موارد")]
        All = 10,
        [EnumDescription("نام کاربری")]
       UserName = 20,
        [EnumDescription("شماره دستگاه")]
        SrcNumber = 30,

        [EnumDescription("شناسه داده")]
        Id = 70,
        [EnumDescription("شناسه یکتا داده")]
        ObjectId = 80,
    }
}
