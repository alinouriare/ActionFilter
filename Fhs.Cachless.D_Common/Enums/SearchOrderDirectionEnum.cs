﻿using Fhs.Cachless.E_Utility.EnumUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum SearchOrderDirectionEnum
    {
        [EnumDescription("صعودی")]
        Ascending = 10,
        [EnumDescription("نزولی")]
        Descending = 20
    }
}
