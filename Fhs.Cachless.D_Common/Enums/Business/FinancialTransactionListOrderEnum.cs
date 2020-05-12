using Fhs.Cachless.E_Utility.EnumUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum FinancialTransactionListOrderEnum
    {
        [EnumDescription("کدارجاع")]
        Id = 10,
        [EnumDescription("کاربر")]
        CurrentUser = 20,
        [EnumDescription("دستگاه")]
        DeviceType = 30,
        [EnumDescription("نوع")]
        TransactionType = 40,
        [EnumDescription("مبدا")]
        Source = 50,
        [EnumDescription("مقصد")]
        Destination = 60,
        [EnumDescription("مبلغ")]
        TransactionValue =70,
        [EnumDescription("کدپیگیری")]
        TrackingCode =80,
        [EnumDescription("تاریخ درخواست")]
        RequestDate = 90,
        [EnumDescription("تاریخ موفقیت")]
        SuccessDate = 100,

    }
}
