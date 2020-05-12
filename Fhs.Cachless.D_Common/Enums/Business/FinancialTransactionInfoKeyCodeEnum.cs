using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum FinancialTransactionInfoKeyCodeEnum
    {
        [EnumDescription("شناسه آی پی عملیات")]
        IpValue = 10,
        
        [EnumDescription("کد سازمان")]
        BillOrganizationCode = 20,

        [EnumDescription("اپراتور تلفن همراه")]
        OperatorType = 30,

        [EnumDescription("کد بسته اینترنتی")]
        PackageCode = 40,

        [EnumDescription("کد رزرو بسته اینترنتی")]
        ReservedChargeInternetCode = 50,

        [EnumDescription("غیر استاندارد")]
        NotStandard = 10000,
    }
}
