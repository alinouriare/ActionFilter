using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum DeviceStateEnum
    {
        NotRegister = 0,
        DeviceActive = 10,
        DeviceInRegister = 30,
        DeviceInActive = 40,
        DeviceBlockByUser =110,
        DeviceBlockByAdmin = 120,
    }
}
