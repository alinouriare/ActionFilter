using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum UserContractDataTypeEnum
    {
        [EnumDescription("-")]
        Null = 0,

        [EnumDescription("شماره کارت")]
        CardNumber = 10,

        [EnumDescription("شماره کارت مخدوش شده")]
        CorruptedCardNumber = 15,

        [EnumDescription("شماره حساب")]
        AccountNumber = 20,

        [EnumDescription("شماره قبض")]
        BillNumber = 30,

        [EnumDescription("شماره قبض سازمانی")]
        BillOrganizationNumber = 31,

        [EnumDescription("شماره تلفن")]
        PhoneNumber = 40,

        [EnumDescription("شماره بیمه")]
        InsuranceId = 50,
        [EnumDescription("کد ترمینال")]
        TerminalId = 60,
    }
}
