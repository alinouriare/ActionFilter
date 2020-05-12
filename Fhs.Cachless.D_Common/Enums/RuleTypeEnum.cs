using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Enums
{
    public enum RuleTypeEnum
    {
        NotStandard = 10,
        ShowCaptchaForThisIP = 20,
        ShowFingerPrintCaptchaForThisIP = 25,
        ConfirmationForThisIP = 30,
    }
}
