using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum NotificationContentTypeEnum
    {
        [EnumDescription("متن ساده")]
        Text = 10,

        [EnumDescription("به صورت HTML")]
        HtmlText = 20
    }
}
