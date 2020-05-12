using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum ConfigGroupEnum
    {
        [EnumDescription("ذخیره موقت سیستم")]
        SystemCache = -10,

        [EnumDescription("غیر استاندارد")]
        NotStandard = 0,

        [EnumDescription("تنظیمات ورود به سیستم")]
        LoginOptions = 10,

        [EnumDescription("تنظیمات نحوه صبر کردن")]
        LoadingOptions = 20,

        [EnumDescription("مدیریت فایل برنامه")]
        AppFileManagement = 30,

        [EnumDescription("اطلاعات برنامه")]
        AppInfo = 40,

        [EnumDescription("تنظیمات سرویس های برنامه")]
        AppServiceSettings = 50,

        [EnumDescription("تنظیمات برنامه")]
        AppSettings = 60,

        [EnumDescription("اطلاعات کاربر ابتدایی برنامه")]
        InstallationUser = 70,
        
    }
}
