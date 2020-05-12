using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ObjectTypeEnum
    {
        Error = -1,
        Null = 0,
        AppDeviceDateLog = 10,
        AppDeviceInfo = 20,
        AppDeviceInfoUserDataRelation = 25,
        ConfigData = 30,
        ConfirmationCode = 40,
        CustomerData = 50,
        FavoriteTransaction = 60,
        FinancialTransaction = 70,
        FinancialTransactionInfoKey = 75,
        LogUserData = 80,
        RoleData = 90,
        UserContact = 100,
        UserData = 110,
        UserPhoneNumber = 120,
        WebApiTokenSession = 130,
        WebApiToken = 140,
        FinancialChannelTransaction = 150,
        IPData = 160,
        IPDataAppDeviceInfoRelation = 165,
        IPDataLogDevice = 170,
        IPDataRule = 180,
        SystemTransactionData = 190,
        NotificationData = 200,
        NotificationDataTarget = 210,
        UserScoreSummery = 220,
        TransactionDuplicateControlData = 230,
        AppRequestLog = 1000,
        FinancialTransactionPerformanceReport = 2000,
    }
}
