using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.E_Utility.EnumUtility;
using Fhs.Cachless.E_Utility.PublicUtility;

namespace Fhs.Cachless.D_Common.Model
{
    public class UserInformation
    {
        #region Variables

        public String FirstName
        {
            get { return _firstName; }
            set
            {
                var temp = value ?? "";
                temp = PublicUtilities.RemovePersianDigitsAndArabicAlphebet(temp);

                _firstName = temp;
            }
        }
        public String LastName
        {
            get { return _lastName; }
            set
            {
                var temp = value ?? "";
                temp = PublicUtilities.RemovePersianDigitsAndArabicAlphebet(temp);

                _lastName = temp;
            }
        }
        public String FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
        public String Email
        {
            get { return _email; }
            set
            {
                var temp = value ?? "";
                temp = PublicUtilities.RemovePersianDigits(temp);

                _email = temp;
            }
        }
        public SexEnum Sex { get; set; }
        public String PersianSex
        {
            get { return EnumUtilities.GetEnumDescription(Sex); }
        }
        public DateTime? BirthDate { get; set; }
        public String PersianBirthDate
        {
            get
            {
                try
                {
                    if (BirthDate == null) return "";

                    return PublicUtilities.ConvertDateTimeToJalali(BirthDate.Value);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public bool IsHeaderNameFull
        {
            get
            {
                var isNameFull = !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrEmpty(FirstName);
                var isLastNameFull = !String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrEmpty(LastName);

                return isNameFull || isLastNameFull;

            }
        }
        public string NationalCode { get; set; }
        public bool? IsProfileComplete { get; set; }

        private String _firstName = "";
        private String _lastName = "";
        private String _email = "";
        #endregion

        public UserInformation()
        {
            MakeDefaults();
        }
        //public UserInformation(string firstName, string lastName, string email = "", SexEnum sex = SexEnum.Null, DateTime? date = null)
        //{
        //    MakeDefaults();

        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Sex = sex;
        //    BirthDate = date;
        //}
        public UserInformation(string firstName, string lastName, string email = "", SexEnum sex = SexEnum.Null, DateTime? date = null, string nationalCode = "")
        {
            MakeDefaults();

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Sex = sex;
            BirthDate = date;
            NationalCode = nationalCode;
        }

        #region Helper Methods

        private void MakeDefaults()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            NationalCode = "";
            Sex = SexEnum.Null;
            BirthDate = null;
        }
        #endregion
    }
}

