namespace TaxCalculator
{
    /// <summary>
    /// Constants for tax slab
    /// </summary>
    internal class TaxCalculatorConstant
    {
        #region Heading, Border, Ask Input Message

        /// <summary>
        /// Heading Border for data transfer time calculator program
        /// </summary>
        public const string HeadingBorder = "==================================================";

        /// <summary>
        /// Heading of data transfer time calculator program
        /// </summary>
        public const string HeadingContent = " Tax Calculator";

        /// <summary>
        /// Border for better Appearance
        /// </summary>
        public const string Border = "---------------------------------";

        /// <summary>
        /// Heading personal Details
        /// </summary>
        public const string PersonalDetailsHeading = "Enter Person Details";

        /// <summary>
        /// Ask for Name
        /// </summary>
        public const string MsgAskName = "Name";

        /// <summary>
        /// Ask for BirthDate
        /// </summary>
        public const string MsgASkBirthdate = "Birth date[DD/MM/YYYY]";

        /// <summary>
        /// Ask for Gender
        /// </summary>
        public const string MsgAskGender = "Gender[M/F]";

        /// <summary>
        /// Heading for account details
        /// </summary>
        public const string AccountDetailsHeading = "Enter Account Details";

        /// <summary>
        /// Ask for Income
        /// </summary>
        public const string MsgAskIncome = "Income";

        /// <summary>
        /// Ask for Investment Amount
        /// </summary>
        public const string MsgAskInvestment = "Investment";

        /// <summary>
        /// Ask for House Loan/Rent Amount
        /// </summary>
        public const string MsgAskLoan = "House Loan/Rent";

        /// <summary>
        /// Heading for Tax Calculation Result
        /// </summary>
        public const string TaxResultHeading = "Tax Calculation Result";

        /// <summary>
        /// Taxable Amount
        /// </summary>
        public const string MsgTaxableAmount = "Taxable Amount";

        /// <summary>
        /// Payable Tax Amount
        /// </summary>
        public const string MsgPayableTax = "Payable Tax Amount";

        /// <summary>
        /// Exit Message
        /// </summary>
        public const string MsgExit = "-----Exit-----";

        /// <summary>
        /// Press Y to continue the program
        /// </summary>
        public const string Yes = "Y";

        /// <summary>
        /// Press N to exit the program
        /// </summary>
        public const string No = "N";

        /// <summary>
        /// Message to ask if user wants to continue the program or not
        /// </summary>
        public const string MsgAskToContinue = "Do you want to Continue[Y/N]?";

        /// <summary>
        /// Ask if user wants to continue or not
        /// </summary>
        public const string MsgWentWrong = "Wrong Input by the User Press 'Y' to continue and 'N' for exit !!!";

        /// <summary>
        /// String M
        /// </summary>
        public const string MsgStringMale = "M";

        /// <summary>
        /// String F
        /// </summary>
        public const string MsgStringFemale = "F";

        /// <summary>
        /// String Male
        /// </summary>
        public const string Male = "Male";

        /// <summary>
        /// String Female
        /// </summary>
        public const string Female = "female";

        /// <summary>
        /// Format for Try Parse Birth date
        /// </summary>
        public const string BirthDateFormat = "dd'/'MM'/'yyyy";

        #endregion

        #region Numeric constants

        /// <summary>
        /// Upper Range for Valid Investment
        /// </summary>
        public const int ValidInvestment = 100000;

        /// <summary>
        /// 80 percent = 80/100 = 0.8
        /// </summary>
        public const double Percent80 = 0.8;

        /// <summary>
        /// Considered Maximum Age of a Human
        /// </summary>
        public const int MaxAge = 120;

        /// <summary>
        /// Age Criteria for Senior Citizen
        /// </summary>
        public const int SeniorAgeLimit = 60;

        /// <summary>
        /// 10 percent = 10/100 = 0.1
        /// </summary>
        public const double Percent10 = 0.1;

        /// <summary>
        /// 20 percent = 20/100 = 0.2
        /// </summary>
        public const double Percent20 = 0.2;

        /// <summary>
        /// 30 percent = 30/100 = 0.3
        /// </summary>
        public const double Percent30 = 0.3;

        /// <summary>
        /// Last Attempt
        /// </summary>
        public const int MaxAttempt = 3;

        /// <summary>
        /// Padding on Right
        /// </summary>
        public const int RightPadding = 24;

        #endregion

        #region Error Message

        /// <summary>
        /// Message for null or empty input
        /// </summary>
        public const string MsgNullInput = "Input cannot be null or Empty.";

        /// <summary>
        /// Message when input is wrong more than 3 times
        /// </summary>
        public const string MsgAttemptsExhausted = "You have attempt wrong Inputs 3 times.";

        /// <summary>
        /// Message for invalid Birth Date
        /// </summary>
        public const string MsgInvalidBirth = "Invalid BirthDate.";

        /// <summary>
        /// Overflow Message
        /// </summary>
        public const string ErrOverflow = "Input is very Large !!! , Try with some Lesser Number";

        /// <summary>
        /// Message for Name cannot be Empty
        /// </summary>
        public const string MsgEmptyName = "Name cannot be empty.";

        /// <summary>
        /// Message for Name Cannot Contain integer
        /// </summary>
        public const string MsgIfIntName = "Name Cannot Contain integer.";

        /// <summary>
        /// BirthDate cannot be greater than Todays date
        /// </summary>
        public const string MsgBirthdateAfterToday = "BirthDate cannot be greater than Todays date.";

        /// <summary>
        /// Birth date cannot be null
        /// </summary>
        public const string MsgNullBirth = "Birth date cannot be null.";

        /// <summary>
        /// Age cannot be greater than 120 years
        /// </summary>
        public const string MsgAgeGreaterThan120 = "Age cannot be greater than 120 years.";

        /// <summary>
        /// Gender can only be 'M' or 'F'
        /// </summary>
        public const string MsgWrongGender = "Gender can only be 'M / Male' or 'F / Female'.";

        /// <summary>
        /// Gender cannot be empty
        /// </summary>
        public const string MsgNullGender = "Gender cannot be empty.";

        /// <summary>
        /// Input can only be a positive integer
        /// </summary>
        public const string ErrNotValidDouble = "Input is not a valid double value.";

        /// <summary>
        /// Message Input should be greater than (someValue)
        /// </summary>
        public const string MsgInputGreaterOrEqualTo = "Input should be greater than or Equal to ";

        /// <summary>
        /// Message Input should be less than (someValue) 
        /// </summary>
        public const string MsgInputLessOrEqualTo = "Input should be Less than or Equal to ";

        /// <summary>
        /// Message for incorrect input Format
        /// </summary>
        public const string ErrIncorrectFormat = "---Incorrect Format--- Error: ";

        /// <summary>
        /// Message for default exception
        /// </summary>
        public const string ErrInvalidDefault = "---Invalid Input by User---. Error: ";

        /// <summary>
        /// Default value if All Income Invested
        /// </summary>
        public const string DefaultAllIncomeInvested = ": 0 (Default)";

        /// <summary>
        /// Message if all Income is invested
        /// </summary>
        public const string MsgAllIncomeInvested = "You have Invested All your income. Hence, No amount left for Home Loan/Rent.";

        #endregion

        #region Tax Slab Ranges for Tax Calculation

        /// <summary>
        /// Male No Tax Range
        /// </summary>
        public const int MaleNoTaxRange = 160000;

        /// <summary>
        /// Tax Slab Upper Range for 10 Tax 
        /// </summary>
        public const int MaleTax10Range = 300000;

        /// <summary>
        /// Tax Slab Upper Range for 20 Tax 
        /// </summary>
        public const int MaleTax20Range = 500000;

        /// <summary>
        /// Female No Tax Range
        /// <summary>
        public const int FemaleNoTaxRange = 190000;

        /// <summary>
        /// Tax Slab Upper Range for 10 Tax 
        /// </summary>
        public const int FemaleTax10Range = 300000;

        /// <summary>
        /// Tax Slab Upper Range for 20 Tax 
        /// </summary>
        public const int FemaleTax20Range = 500000;

        /// <summary>
        /// Senior No Tax Range
        /// </summary>
        public const int SeniorNoTaxRange = 240000;

        /// <summary>
        /// Tax Slab Upper Range for 10 Tax 
        /// </summary>
        public const int SeniorTax10Range = 300000;

        /// <summary>
        /// Tax Slab Upper Range for 20 Tax 
        /// </summary>
        public const int SeniorTax20Range = 500000;

        #endregion
    }
}
