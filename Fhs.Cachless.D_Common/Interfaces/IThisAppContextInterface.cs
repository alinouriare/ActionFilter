using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.E_Utility.EncryptDecryptUtility.Models;

namespace Fhs.Cachless.D_Common.Interfaces
{
    public interface IThisAppContextInterface
    {
        #region Get Application Title

        String GetApplicationName();
        String GetApplicationTitle();
        String GetApplicationVersion();

        #endregion

        #region Application File Management 

        String GetApplicationBaseRoot();
        String GetApplicationTempRelativeAddress();
        String GetApplicationLogFileRootRelativeAddress();
        String GetApplicationConfigFileRootRelativeAddress();

        #endregion

        #region User Management Data

        IdentifyClass GetCurrentUserId();
        String GetCurrentUserName();
        String GetCurrentUserNickName();

        #endregion

        #region ConfigurationManagement

        /// <summary>
        /// اطلاعات کانفیگ سیستم را باز می گرداند
        /// </summary>
        /// <param name="userId">اگر خالی باشد به معنی اطلاعات سیستم است و اگر پر باشد یعنی اطلاعات کانفیگی که کاربر تنظیم کرده است</param>
        /// <param name="configGroup">گروه کانفیگ</param>
        /// <param name="configName">نام کانفیگ</param>
        /// <returns></returns>
        ConfigurationData GetConfigData(Guid? userId, String configGroup, String configName);

        /// <summary>
        /// اضافه کردن یک کانفیگ به سیستم
        /// </summary>
        /// <param name="userId">شناسه کاربری در صورتی که خالی باشد کانفیگ سیستمی فرض می شود</param>
        /// <param name="configGroup">گروه کانفیگ</param>
        /// <param name="configName">نام کانفیگ</param>
        /// <param name="valueData">مقدار کانفیگ</param>
        bool AddConfigData(Guid? userId, String configGroup, String configName, Object valueData);

        #endregion

        #region Add Log To System

        bool AddInformationLogInDataBase(InformationLog data, IdentifyClass userId = null, IdentifyClass dataId = null);

        bool AddInformationLogInFile(InformationLog data, IdentifyClass userId = null, IdentifyClass dataId = null);

        #endregion

        #region Token Management

        bool IsDebugeMode();
        bool IsExecuteDLLInDebugMode();
        bool IsEncryptDataActive();
        TokenHelper GetMainToken();

        #endregion

    }
}
