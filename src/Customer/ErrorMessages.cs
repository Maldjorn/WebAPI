using System;
using System.Collections.Generic;
using System.Text;

namespace CM.Customers.Validators
{
    class  ErrorMessages
    {
        //Customer
        public readonly string FirsNameLenght = "Maximum length should be no more than 50";
        public readonly string SecondNameLenght = "Maximum length should be no more than 50";
        public readonly string SecondNameNotEmpty = "Second name can't be empty";
        public readonly string AddressesNotEmpty = "Addresses can't be empty";
        public readonly string InvaildPhoneFormat = "Invalid phone format";
        public readonly string InvalidEmailFormat = "Invalid email format";
        public readonly string NotesNotEmpty = "Notes are requaired";

        //Addresses
        public readonly string FirstAddressLineLength = "Maximum length should be no more than 100";
        public readonly string SecondAddressLineLength = "Maximum length should be no more than 100";
        public readonly string FirstAddressLineNotEmpty = "First address line can't be empty";
        public readonly string CityLength = "Maximum length should be no more than 50";
        public readonly string CityNotEmpty = "City can't be empty";
        public readonly string PostalCodeLength = "Maximum length should be no more than 6";
        public readonly string PostalCodeNotEmpty = "Postal code can't be empty";
        public readonly string InvalidCountry = "You can only select the USA or Canada";
        public readonly string StateNotEmpty = "State can't be empty";
        public readonly string StateLength = "Maximum length should be no more than 20";

    }
}
