using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum InsurancePackageTypeEnum
    {
        [EnumDescription("بیمه آتش سوزی")]
        FireInsureanceType = 2,

        [EnumDescription("بیمه حوادث انفرادی")]
        IndividualEventsInsureanceType = 4,

        [EnumDescription("بیمه مسافرت خارجی")]
        TravelingAbroadInsureanceType = 6,

    }
}
