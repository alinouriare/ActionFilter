﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum FinancialTransactionErrorListDetailsSearchEnum
    {
        [EnumDescription("همه موارد")]
        All = 10,
        [EnumDescription("شماره موبایل ")]
        PhoneNumber = 15,
        [EnumDescription("مبلغ تراکنش")]
        TransactionValue = 20,
        [EnumDescription("شماره مبداً")]
        SrcNumber = 30,
        [EnumDescription("شماره مقصد")]
        DestNumber = 40,
        [EnumDescription("کد پیگیری")]
        TrackingCode = 50,
        [EnumDescription("توضیحات")]
        Description = 55,
        [EnumDescription("شناسه داده")]
        Id = 60,
        [EnumDescription("شناسه یکتا داده")]
        ObjectId = 70,
    }
}
