using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ApplicationModeEnum
    {
        [EnumDescription("نامشخص")]
        Null = 0,

        [EnumDescription("درگاه وب سرویس")]
        WebApiMode = 10,

        [EnumDescription("درگاه کنترل پنل")]
        ControlPanelMode = 20
    }
}
