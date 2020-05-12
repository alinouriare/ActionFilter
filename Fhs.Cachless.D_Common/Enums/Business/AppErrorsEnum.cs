using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.E_Utility.EnumUtility.Attribute;

namespace Fhs.Cachless.D_Common.Enums.Business
{
    public enum AppErrorsEnum
    {
        #region WebCoreClient Errors = -10000

        [EnumDescription("سامانه در انتخاب سرور مقصد دچار مشکل شده است!")]
        System_Could_Not_Found_ServerTarget = -10000,

        #endregion

        #region Channel Erros = -18000

        [EnumDescription("بدنه مدل ارسالی به سرور مرکزی داخلی است")]
        Channel_App_Request_Body_Was_Empty = -18000,

        [EnumDescription("شناسه درخواست به سرورمرکزی یافت نشد")]
        Channel_App_RequestId_Not_Found = -18010,

        [EnumDescription("شکست در ورود به برنامه مرکزی")]
        Channel_Loggined_Failed = -18020,

        [EnumDescription("شما تنها می تواند عملیات کارت به کارت را روزانه 10 بار انجام دهید")]
        You_Can_Only_Do_CardTransfer_Operation_10_Times_In_A_Day = -18030,

        [EnumDescription("اطلاعات کاربری یافت نگردید")]
        Channel_ClientInfo_Not_Found = -18040,

        #endregion

        #region Public System Error = -19000

        [EnumDescription("داده ای جهت ارسال یافت نگردید")]
        Sending_Data_Not_Found = -19000,

        [EnumDescription("داده ای جهت ارسال یافت نگردید")]
        TransactionId_Or_User_Info_Not_Found = -19002,

        [EnumDescription("سامانه قادر به ذخیره سازی اطلاعات تراکنش نمی باشد")]
        System_Can_Not_Save_Transaction_Data = -19004,

        [EnumDescription("سامانه قادر به ذخیره سازی اطلاعات کارت نمی باشد")]
        System_Can_Not_Save_User_Contact_Data = -19010,

        [EnumDescription("سامانه قادر به ذخیره سازی اطلاعات وضعیت کاربری نمی باشد")]
        System_Can_Not_Save_User_Session_Api_Data = -19020,

        [EnumDescription("عملیات با شکست مواجه شد")]
        Operation_Failed = -19120,

        [EnumDescription("شناسه عملیات یافت نشد")]
        Operation_Id_Not_Found = -19130,

        [EnumDescription("تبدیل مدل ورودی به مدل سیستم با شکست روبرو شد")]
        Failed_To_Converting_Input_Model_To_System_Model = -19140,

        [EnumDescription("تبدیل مدل دریافت شده به مدل سیستم با شکست روبرو شد")]
        Failed_To_Converting_Output_Model_To_System_Model = -19142,

        [EnumDescription("اطلاعات جهت ارسال یافت نشد")]
        Session_Data_Not_Found = -19150,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی - نامشخص)")]
        Unknwon_Error_Operation_Failed = -19160,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی - چنل اتصال)")]
        Channel_Unknwon_Error_Operation_Failed = -19170,

        [EnumDescription("فراخوانی سرویس موفقیت آمیز نمی باشد")]
        Channel_Unknwon_Error_Service_Failed = -19172,

        [EnumDescription("فراخوانی سرویس برنامه مرکزی با شکست روبرو گردید")]
        Channel_Unknwon_Error_Calling_AppCore_Failed = -19174,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای ارتباط به چنل)")]
        Channel_Communication_Error_Operation_Failed = -19180,

        [EnumDescription("عملیات با شکست مواجه شده است (ارتباط به برنامه مرکزی)")]
        Channel_Aggregation_Error_Operation_Failed = -19182,

        [EnumDescription("خطای ورود به چنل")]
        Channel_Login_Failed = -19185,

        [EnumDescription("ارسال پیامک با خطا روبرو گردید")]
        Sending_Sms_Failed = -19190,

        [EnumDescription("خطا در استعلام شماره تماس و اطلاعات مشتری بانک")]
        Get_Bank_Customer_Error = -19200,

        [EnumDescription("فراخوانی برنامه مرکزی با موفقیت انجام نگرفت - خطای داخلی")]
        Calling_Core_Api_Was_Not_Success = -19210,


        [EnumDescription("عدم امکان استعلام، شماره تماس، لطفا بعد از چند ثانیه مجدداً تلاش کنید")]
        Inquery_PhoneNumber_Failed = -19220,

        [EnumDescription("کد درخواست یافت نگردید!")]
        RequestId_Not_Found = -19230,

        [EnumDescription("خطا در استعلام کارت")]
        Inquiry_Card_Error = -19240,

        [EnumDescription("تراکنش تکراری می باشد لطفا پس از یک دقیقه مجددا تلاش کنید")]
        Duplicate_Transaction_Control = -19250,


        #endregion

        #region Keshavarzi Errors = -200000

        [EnumDescription("ورود به درگاه بانک با شکست روبرو گردید (ks)")]
        Can_not_Create_Login_Object = -200000,

        [EnumDescription("پاسخ خطا از سرور بانک کشاورزی (ks)")]
        Keshavarzi_Public_Errors = -200005,

        [EnumDescription("عدم دریافت پاسخ مناسب از سرور مرکزی بانک کشاورزی (ks)")]
        Keshavarzi_Response_Was_Null = -200010,

        [EnumDescription("فراخونی سرویس درگاه بانک با شکست روبرو شده است (ks)")]
        Keshavarzi_Aggregation_Failed = -200020,

        [EnumDescription(" از سرور مرکزی پاسخی دریافت نشد! نتیجه تراکنش کارت به کارت نامشخص است (ks)")]
        Keshavarzi_Unknown_Result_CardTo_Card = -200030,

        #endregion

        #region Mellal Errors = -210000

        [EnumDescription("خطای عمومی در فراخوانی سرویس بانک ملل")]
        Mellal_Public_Exception_Errors = -210000,

        [EnumDescription("نبود دسترسی - اطلاعات ورود غلط است")]
        Mellal_Error_501 = -210010,

        [EnumDescription("امکان اتصال به چنل بانک ملل وجود ندارد")]
        Mellal_Error_50 = -210020,

        [EnumDescription("چک سام غلط است")]
        Mellal_Error_61 = -210030,

        [EnumDescription("زمان ارسالی به سرور غلط است")]
        Mellal_Error_62 = -210040,

        [EnumDescription("کارت مبدا متعلق به ملل نمی باشد")]
        Mellal_Error_102 = -210050,

        #endregion

        #region Sarmad Errors = -220000

        [EnumDescription("خطا در ارتباط با بیمه سرمد")]
        Sarmad_ConnectionFailed = -220010,

        [EnumDescription("از سرور پاسخی دریافت نشد! نتیجه نامشخص است")]
        Sarmad_The_Server_Does_Not_Respond = -220015,

        [EnumDescription("خطای عمومی با سرور بیمه سرمد")]
        Sarmad_PublicUnknownErrors = -220020,

        [EnumDescription("ورودی متعلق به بیمه حوادث انفرادی نمی باشد")]
        Sarmad_This_Methode_Is_Not_A_IndividualEvents_Insurance = -220050,

        [EnumDescription("ورودی متعلق به بیمه آتش سوزی نمی باشد")]
        Sarmad_This_Methode_Is_Not_A_Fire_Insurance = -220052,

        [EnumDescription("کد بیمه نامشخص است")]
        Sarmad_Tahod_Kind_Not_Valid = -220060,

        [EnumDescription("کد عملیات یافت نشد")]
        Sarmad_Code_Not_Found = -220062,

        [EnumDescription("شناسه سفارش عملیات را مشخص کنید!")]
        Sarmad_Id_Not_Valid = -220063,

        [EnumDescription("کد ملی یافت نشد!")]
        Sarmad_NationalId_Not_Found = -220064,

        [EnumDescription("شماره موبایل یافت نشد")]
        Sarmad_MobileNumber_Found = -220066,

        [EnumDescription("تاریخ تولد نامشخص است")]
        Sarmad_BirthDate_Not_Found = -220068,

        [EnumDescription("کد سریال درون سامانه نامشخص است")]
        Sarmad_SerialText_Not_Found = -220070,

        [EnumDescription("کد پرداخت بانکی را مشخص کنید")]
        Sarmad_PayRefNo_Not_Found = -220072,

        [EnumDescription("کد رسید عملیات را مشخص کنید")]
        Sarmad_ReceiveNo_Not_Found = -220074,

        [EnumDescription("کد شرکت منفی است")]
        Sarmad_CompanyId_Not_Valid = -220076,

        [EnumDescription("کد جنسیت نامشخص است")]
        Sarmad_Gender_Not_Valid = -220078,

        [EnumDescription("کد شهر را وارد کنید")]
        Sarmad_CityId_Not_Valid = -220080,

        [EnumDescription("آدرس را به درستی وارد کنید")]
        Sarmad_Address_Not_Valid = -220090,

        [EnumDescription("کد پستی صحیح نمی باشد")]
        Sarmad_PostalCode_Not_Valid = -220092,

        [EnumDescription("کد سفارش یافت نشد")]
        Sarmad_OrderId_Not_Valid = -220094,

        [EnumDescription("استعلام نوع بیمه درخواستی با شکست روبرو شد")]
        Sarmad_Inquiry_InsuranceType_Failed = -220100,

        [EnumDescription("نوع بیمه درخواستی یافت نشد!")]
        Sarmad_InsuranceType_Not_Found = -220110,

        [EnumDescription("قیمت درخواستی خرید بیمه با قیمت ثبت شده در سامانه بیمه سرمد تطابق ندارد")]
        Sarmad_InsurancePrice_Does_Not_EQual_To_EntryData_Price = -220120,

        [EnumDescription("دلیل لغو عملیات را وارد کنید!")]
        Sarmad_Fill_Reject_Reason = -220140,

        #endregion
        
        #region ChargeInternet Errors = -230000

        [EnumDescription("خطا در اتصال به درگاه رزرو بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_EndpointNotFound_MoenShopReserve = -230000,

        [EnumDescription("عدم اتصال به سرور درگاه رزرو بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_Socket_MoenShopReserve = -230010,

        [EnumDescription("عدم اتصال به درگاه رزرو بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_SecurityNegotiation_MoenShopReserve = -230020,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی رزرو بسته اینترنتی- اتصال)")]
        ChargeInternet_Unknwon_Error_Operation_Failed_MoenShopReserve = -230030,

        [EnumDescription("خطای نامشخص هنگام رزرو بسته اینترنتی")]
        ChargeInternet_Unknwon_Error_MoenShopReserve = -230040,

        [EnumDescription("خطا در هنگام رزرو بسته اینترنتی")]
        ChargeInternet_Error_MoenShopReserve = -230050,


        [EnumDescription("خطا در اتصال به درگاه خرید بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_EndpointNotFound_MoenShopSale = -230060,

        [EnumDescription("عدم اتصال به سرور درگاه خرید بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_Socket_MoenShopSale = -230070,

        [EnumDescription("عدم اتصال به درگاه خرید بسته اینترنتی")]
        ChargeInternet_Public_NotConnection_Errors_SecurityNegotiation_MoenShopSale = -230080,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی خرید بسته اینترنتی- اتصال)")]
        ChargeInternet_Unknwon_Error_Operation_Failed_MoenShopSale = -230090,



        [EnumDescription("خطا در هنگام خرید بسته اینترنتی ایرانسل")]
        ChargeInternet_Error_MoenShopSaleMTN = -230110,
        [EnumDescription("خطای نامشخص هنگام خرید بسته اینترنتی ایرانسل")]
        ChargeInternet_Unknwon_Error_MoenShopSaleMTN = -230120,
        [EnumDescription("خطا در هنگام خرید بسته اینترنتی")]
        ChargeInternet_Error_MoenShopSale = -230130,
        
        [EnumDescription("خطای نامشخص هنگام خرید بسته اینترنتی")]
        ChargeInternet_Unknwon_Error_MoenShopSale = -230140,

        #endregion

        #region PhoneCharge Errors = -240000

        [EnumDescription("خطا در اتصال به درگاه رزرو شارژ")]
        PhoneCharge_Public_NotConnection_Errors_EndpointNotFound_MoenShopReserve = -240000,

        [EnumDescription("عدم اتصال به سرور درگاه رزرو شارژ")]
        PhoneCharge_Public_NotConnection_Errors_Socket_MoenShopReserve = -240010,

        [EnumDescription("عدم اتصال به درگاه رزرو شارژ")]
        PhoneCharge_Public_NotConnection_Errors_SecurityNegotiation_MoenShopReserve = -240020,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی رزرو شارژ- اتصال)")]
        PhoneCharge_Unknwon_Error_Operation_Failed_MoenShopReserve = -240030,

        [EnumDescription("خطای نامشخص هنگام رزرو شارژ")]
        PhoneCharge_Unknwon_Error_MoenShopReserve = -240040,

        [EnumDescription("خطا در هنگام رزرو شارژ")]
        PhoneCharge_Error_MoenShopReserve = -240050,


        [EnumDescription("خطا در اتصال به درگاه خرید شارژ")]
        PhoneCharge_Public_NotConnection_Errors_EndpointNotFound_MoenShopSale = -240060,

        [EnumDescription("عدم اتصال به سرور درگاه خرید شارژ")]
        PhoneCharge_Public_NotConnection_Errors_Socket_MoenShopSale = -240070,

        [EnumDescription("عدم اتصال به درگاه خرید شارژ")]
        PhoneCharge_Public_NotConnection_Errors_SecurityNegotiation_MoenShopSale = -240080,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی خرید شارژ- اتصال)")]
        PhoneCharge_Unknwon_Error_Operation_Failed_MoenShopSale = -240090,



        [EnumDescription("خطا در هنگام خرید شارژ ایرانسل")]
        PhoneCharge_Error_MoenShopSaleMTN = -240110,
        [EnumDescription("خطای نامشخص هنگام خرید شارژ ایرانسل")]
        PhoneCharge_Unknwon_Error_MoenShopSaleMTN = -240120,
        [EnumDescription("خطا در هنگام خرید شارژ ")]
        PhoneCharge_Error_MoenShopSale = -240130,

        [EnumDescription("خطای نامشخص هنگام خرید شارژ")]
        PhoneCharge_Unknwon_Error_MoenShopSale = -240140,

        #endregion

        #region Sejam Errors = -250000

        //Sejam Error Messages
        [EnumDescription("شماره موبایل اشتباه است")]
        Sejam_InvalidMsisdn = -260010,
        [EnumDescription("زمان اعتبار کد تأیید به پایان رسیده است")]
        Sejam_InvalidOtpTime = -260020,
        [EnumDescription("ثبت نام تکمیل نشده است")]
        Sejam_IncompleteRegistrations = -260030,
        [EnumDescription("کد پیگیری اشتباه است")]
        InvalidTraceCode = -260040,
        [EnumDescription("حجم تصویر زیاد است")]
        Sejam_ImageTooLarge = -260050,
        [EnumDescription("کاربر اعتبارسنجی نشد")]
        Sejam_Unuatorized = -260060,
        [EnumDescription("کاربر معلق می باشد")]//(متن دستی (کاربر قفل است
        LockedUser = -260070,
        [EnumDescription("کد تأیید نامعتبر است")]
        Sejam_InvalidOtp = -260080,
        [EnumDescription("کد تأیید نامعتبر است")]
        Sejam_NotFound = -260090,
        [EnumDescription("سرویس تعریف نشده است")]
        Sejam_UndefinedService = -260100,
        [EnumDescription("")]
        Sejam_ThirdPartyServiceNotFound = -260110,
        [EnumDescription("")]
        Sejam_Conflicts = -260120,
        [EnumDescription("نوع فایل پشتیبانی نمی شود")]
        Sejam_Sejam_UnsupportedMediaType = -260130,
        [EnumDescription("تعداد درخواست سرویس بیش از حد مجاز")]
        Sejam_ToManyRequest = -260140,
        [EnumDescription("خطای ناشناخته")]
        Sejam_UnknownServerError = -260150,
        [EnumDescription("عدم ارسال اس ام اس")]
        Sejam_FailedSendSms = -260160,
        [EnumDescription("پرداخت ناموفق")]
        Sejam_FailedPayment = -260170,
        [EnumDescription("عملیات با شکست مواجه شده است (ارتباط به برنامه مرکزی)")]
        Sejam_Aggregation_Error_Operation_Failed = -260180,

        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی -  اتصال به سجام)")]
        Sejam_Unknwon_Error_Operation_Failed = -260190,
        #region Model Errors

        [EnumDescription("خطای عمومی کنترل درخواست")]
        Sejam_CheckModelError = -260195,

        [EnumDescription("توکن یافت نشد!")]
        Sejam_Token_NotFound = -2601100,

        //personInfo
        [EnumDescription("پاسخی از سرور سجام دریافت نشد")]
        Sejam_The_Server_Does_Not_Respond = -2602600,
        [EnumDescription("نام کاربری سجام نامعتبر است")]
        Sejam_Username_InValid = -260270,
        [EnumDescription("رمز عبور سجام نامعتبر است")]
        Sejam_Password_InValid = -260280,
        [EnumDescription("شماره همراه صحیح نمی باشد")]
        Sejam_Mobile_Invalid = -2602900,
        [EnumDescription("شماره همراه مجاز نمی باشد")]
        Sejam_Mobile_InvalidCount = -2602901,
        [EnumDescription("شماره OTP یافت نشد")]
        Sejam_OTP_NotFound = -260295,
        [EnumDescription("کدملی نامعتبر است")]
        Sejam_NationalCode_Invalid = -260300,
        [EnumDescription("کد تأیید ارسال شده نامعتبر است")]
        Sejam_Otp_Invalid = -260310,
        [EnumDescription("نام نامعتبر است")]
        Sejam_FirstName_Invalid = -260320,
        [EnumDescription("نام خانوادگی نامعتبر است")]
        Sejam_LastName_Invalid = -260330,
        [EnumDescription("نام پدر نامعتبر است")]
        Sejam_FatherName_Invalid = -260340,
        [EnumDescription("جنسیت نامعتبر است")]
        Sejam_Gender_Invalid = -260350,
        [EnumDescription(" سری حروف شناسنامه نامعتبر می باشد")]
        Sejam_SeriShChar_Invalid = -260360,
        [EnumDescription("سری عددی شناسنامه نامعتبر می باشد")]
        Sejam_SeriSh_Invalid = -260370,

        [EnumDescription("سریال شناسنامه نامعتبر می باشد")]
        Sejam_Serial_Invalid = -260380,

        [EnumDescription("شماره شناسنامه نامعتبر می باشد")]
        Sejam_ShNumber_Invalid = -260390,
        [EnumDescription("تاریخ تولد نامعتبر می باشد")]
        Sejam_BirthDate_Invalid = -260400,
        [EnumDescription("تاریخ تولد با فرمت درست وارد نشده است")]
        Sejam_BirthDate_InvalidFormat = -260405,
        [EnumDescription("محل صدور شناسنامه نامعتبر می باشد")]
        Sejam_PlaceOfIssue_Invalid = -260410,
        [EnumDescription("محل تولد نامعتبر می باشد")]
        Sejam_PlaceOfBirth_Invalid = -260420,
        
        //address
        [EnumDescription("کدپستی نامعتبر است")]
        Sejam_PostalCode_Invalid = -260430,
        [EnumDescription("کشور نامعتبر است")]
        Sejam_CountryId_Invalid = -260440,
        [EnumDescription("استان نامعتبر است")]
        Sejam_ProvinceId_Invalid = -260450,
        [EnumDescription("شهر نامعتبر است")]
        Sejam_CityId_Invalid = -260460,
        [EnumDescription("خیابان نامعتبر است")]
        Sejam_RemnantAddress_Invalid = -260470,
        [EnumDescription("کوچه نامعتبر است")]
        Sejam_Alley_Invalid = -260480,
        [EnumDescription("پلاک نامعتبر است")]
        Sejam_Plaque_Invalid = -260490,
        [EnumDescription("کدشهر نامعتبر است")]
        Sejam_CityPrefix_Invalid = -260500,
        [EnumDescription("شماره تلفن نامعتبر است")]
        Sejam_Tel_Invalid = -260510,
        
        //payment
        [EnumDescription("مبلغ پرداختی نامعتبر است")]
        Sejam_Amount_Payment_Invalid = -260520,
        [EnumDescription("کد ارجاع پرداخت نامعتبر است")]
        Sejam_ReferenceNumber_Invalid = -260530,
        [EnumDescription("شماره سریال پرداخت نامعتبر است")]
        Sejam_SaleReferenceId_Invalid = -260540,
        [EnumDescription("مبلغ تخفیف نامعتبر است")]
        Sejam_Discount_Invalid = -260550,
        [EnumDescription("تاریخ نامعتبر است")]
        Sejam_DateTime_Payment_Invalid = -260560,

        //jobInfo
        [EnumDescription("شناسه شغل نامعتبر است")]
        Sejam_JobId_Invalid = -260180,
        [EnumDescription("نام شرکت نامعتبر است")]
        Sejam_CompanyName_Invalid = -2601900,
        [EnumDescription("آدرس شرکت نامعتبر است")]
        Sejam_CompanyAddress_Invalid = -260200,
        [EnumDescription("کد پستی شرکت نامعتبر است")]
        Sejam_CompanyPostalCode_Invalid = -260210,
        [EnumDescription("پست الکترونیک شرکت نامعتبر است")]
        Sejam_CompanyEmail_Invalid = -260220,
        [EnumDescription("کد شهر محل شرکت نامعتبر است")]
        Sejam_CompanyCityPrefix_Invalid = -260230,
        [EnumDescription("شماره تماس شرکت نامعتبر است")]
        Sejam_CompanyPhone_Invalid = -260240,
        [EnumDescription("سمت شغلی نامعتبر است")]
        Sejam_Position_Invalid = -260250,
        [EnumDescription("تاریخ اشتغال نامعتبر است")]
        Sejam_EmploymentDate_Invalid = -260251,
        //FinancialInfo
        [EnumDescription("پیش بینی سطح ارزش ریالی معاملات نامعتبر است")]
        Sejam_TransactionLevel_Invalid = -260260,

        [EnumDescription("میزان آشنایی با مفاهیم مالی را مشخص کنید")]
        Sejam_TradingKnowledgeLevel_Invalid = -260270,
        //bankaccount
        [EnumDescription("شماره حساب نامعتبر است")]
        Sejam_AccountNumber_Invalid = -260280,
        [EnumDescription("شماره حساب وارد شده متعلق به بانک صادرات نمی باشد")]
        Sejam_AccountNumber_InvalidAccountSaderat = -260281,
        [EnumDescription("نوع حساب نامعتبر است")]
        Sejam_AccountType_Invalid = -260290,
        [EnumDescription("شماره شبا حساب نامعتبر است")]
        Sejam_Sheba_Invalid = -260300,
        [EnumDescription("شناسه بانک نامشخص است")]
        Sejam_BankId_Invalid = -260310,

        [EnumDescription("کد شعبه نامشخص است")]
        Sejam_BranchCode_Invalid = -260320,
        [EnumDescription("نام شعبه نامشخص است")]
        Sejam_BranchName_Invalid = -260330,
        [EnumDescription("کد شهر شعبه نامشخص است")]
        Sejam_BranchCityId_Invalid = -260340,

        [EnumDescription("فرمت فیلدهای ورودی به سرویس سجام نامعتبر است")]
        Sejam_RequestFormat_Invalid = -2603500,
        [EnumDescription("فرمت مدل ورودی به سرویس سجام نامعتبر است")]
        Sejam_ModelFormat_Invalid = -2603600,
        #endregion

        #endregion

        #region CardStatement = -260000

        [EnumDescription("شماره حساب یافت نشد!")]
        CardStatement_NotFound_AccountNumber= -260010,

        [EnumDescription("شکست در یافتن شماره حساب!")]
        CardStatement_Fail_AccountNumber = -260020,
        #endregion

        #region Parsian Bank Errors = -270000

        [EnumDescription("خطای عمومی درگاه پارسیان")]
        Parsian_General_Error = -270005,

        [EnumDescription("نقطه اتصال به درگاه پارسیان یافت نگردید")]
        Parsian_EndPoint_Not_Found = -270010,

        [EnumDescription("خطای عمومی در هنگام لاگین به درگاه پارسیان")]
        Parsian_Login_Public_Error = -270020,

        [EnumDescription("پاسخ لاگین درگاه پارسیان نامشخص است")]
        Parsian_Login_Response_Is_Empty = -270022,

        [EnumDescription("کد نشست لاگین درگاه پارسیان یافت نگردید")]
        Parsian_Login_Session_Id_Not_Found = -270024,

        [EnumDescription("خطای عمومی در هنگام استعلام کارت به کارت درگاه پارسیان")]
        Parsian_InitCardTransfer_Public_Error = -270030,

        [EnumDescription("پاسخ سرویس استعلام کارت خالی است")]
        Parsian_InitCard_Response_Is_Empty = -270035,

        [EnumDescription("مدل داخلی استعلام کارت خالی است")]
        Parsian_InitCard_Inner_Response_Is_Empty = -270036,
        
        [EnumDescription("خطای عمومی در هنگام عملیات کارت به کارت درگاه پارسیان")]
        Parsian_CardTransfer_Public_Error = -270040,

        [EnumDescription("خطا در استعلام کارت مقصد از درگاه پارسیان")]
        Parsian_InitCard_Failed = -270045,

        [EnumDescription("خطای عمومی تفسیر خطای درگاه پارسیان")]
        Parsian_Generate_Erorr_Message_Public_Error = -270050,

        [EnumDescription("پاسخ سرویس انتقال وجه کارت به کارت خالی است")]
        Parsian_CardTransfer_Response_Is_Empty = -270060,

        [EnumDescription("مدل داخلی انتقال وجه کارت به کارت خالی است")]
        Parsian_CardTransfer_Inner_Response_Is_Empty = -270070,


        #endregion

        #region Refah Errors = -280000

        [EnumDescription("خطای عمومی بانک رفاه")]
        Refah_Public_Errors = -280000,

        [EnumDescription("بدنه پاسخ درگاه رفاه خالی است")]
        Refah_Login_Response_Is_Empty = -280010,

        [EnumDescription("نقطه اتصال به درگاه بانک رفاه یافت نگردید")]
        Refah_EndPoint_Not_Found = -280020,

        [EnumDescription("خطای عمومی ورود به درگاه بانک رفاه")]
        Refah_Login_Public_Error = -280030,

        [EnumDescription("کلید نشست جهت ورود به درگاه رفاه دریافت نگردید")]
        Refah_Login_Session_Id_Not_Found = -280040,

        [EnumDescription("بدنه پاسخ استعلام کارت درگاه رفاه خالی است")]
        Refah_InitCard_Response_Is_Empty = -280050,

        [EnumDescription("بدنه پاسخ داخلی استعلام کارت درگاه رفاه خالی است")]
        Refah_InitCard_InnerResponse_Is_Empty = -280060,

        [EnumDescription("وضیعت بدنه پاسخ داخلی استعلام کارت درگاه رفاه خالی است")]
        Refah_InitCard_InnerResponse_Status_Is_Empty = -280061,


        [EnumDescription("اطلاعات مشتری در پاسخ بانک رفاه یافت نگردید")]
        Refah_InitCard_PersonInfo_Not_Found = -280070,

        [EnumDescription("خطای عمومی در استعلام کارت به کارت بانک رفاه ")]
        Refah_InitCardTransfer_Public_Error = -280080,

        [EnumDescription("شکست در استعلام کارت مبدا")]
        Refah_InitCard_Failed = -280085,

        [EnumDescription("خطای عمومی در عملیات کارت به کارت بانک رفاه")]
        Refah_CardTransfer_Public_Error = -280090,

        [EnumDescription("بدنه پاسخ عملیات کارت به کارت درگاه رفاه خالی است")]
        Refah_CardTransfer_Response_Is_Empty = -280092,

        [EnumDescription("بدانه داخلی پاسخ عملیات کارت به کارت درگاه رفاه خالی است")]
        Refah_CardTransfer_InnerResponse_Is_Empty = -280094,

        [EnumDescription("پاسخ نهایی عملیات کارت به کارت بانک رفاه یافت نگردید")]
        Refah_CardTransfer_MainResult_Is_Empty = -280094,

        [EnumDescription("وضیعت پاسخ نهایی عملیات کارت به کارت بانک رفاه یافت نگردید")]
        Refah_CardTransfer_MainResult_Status_Is_Empty = -280095,


        #endregion
        
        #region Tavanir Errors = -290000

        //Tavanir Error Messages
       [EnumDescription("نام کاربری توانیر نامعتبر است")]
        Tavanir_Username_InValid = -290010,
        [EnumDescription("رمز عبور توانیر نامعتبر است")]
        Tavanir_Password_InValid = -290020,
        [EnumDescription("پاسخی از سرور توانیر دریافت نشد")]
        Tavanir_The_Server_Does_Not_Respond = -290030,
        [EnumDescription("عملیات با شکست مواجه شده است (خطای داخلی -  اتصال به توانیر)")]
        Tavanir_Unknwon_Error_Operation_Failed = -290040,
        [EnumDescription("توکن یافت نشد!")]
        Tavanir_Token_NotFound = -260050,
        [EnumDescription("شماره تلفن همراه توانیر نامعتبر است")]
        Tavanir_MobileNumber_InValid = -290060,
        [EnumDescription("شناسه قبض توانیر نامعتبر است")]
        Tavanir_BillId_InValid = -290070,
        [EnumDescription("سال شروع توانیر نامعتبر است")]
        Tavanir_FromYear_InValid = -290080,
        #endregion
    }
}
