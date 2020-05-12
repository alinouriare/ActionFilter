using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum TransactionTypeEnum
    {
        [EnumDescription("نامشخص")]
        Null = 0,

        [EnumDescription("مانده کارت - حساب")]
        CardBalance = 10,

        [EnumDescription("گردش کارت")]
        CardStatement = 20,

        [EnumDescription("استعلام کارت")]
        InitCard = 24,

        [EnumDescription("مقدمات کارت به کارت")]
        InitCardTransfer = 25,

        [EnumDescription("کارت به کارت")]
        CardTransfer = 30,

        [EnumDescription("پرداخت قبض")]
        BillPay = 40,

        [EnumDescription("پرداخت وجوه سازمانی")]
        BillOrganizationPay = 41,


        [EnumDescription("دریافت قبض همراه اول")]
        GetMciBill = 44,


        [EnumDescription("استعلام قبض")]
        InitBill = 45,

        [EnumDescription("خرید شارژ")]
        ChargeBuy = 50,

        [EnumDescription("خرید بسته اینترنت")]
        InternetChargeBuy = 60,

        [EnumDescription("خرید بیمه سرمد")]
        SarmadInsuranceBuy = 70,

        [EnumDescription("پرداخت خیریه")]
        CharityPayment = 80,

        [EnumDescription("پرداخت سجام")]
        SejemPayment = 90

    }
}
