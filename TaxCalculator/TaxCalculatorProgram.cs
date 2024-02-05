using System;
using System.Globalization;
using System.Linq;

namespace TaxCalculator
{
    /// <summary>
    /// Tax Calculation Program
    /// </summary>
    internal class TaxCalculatorProgram
    {
        /// <summary>
        /// Main method for Tax Calculation
        /// </summary>
        public static void Main()
        {
            string continueCondition = TaxCalculatorConstant.Yes;
            int continueAttempt = 0;

            while (continueCondition.Equals(TaxCalculatorConstant.No, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                if (continueCondition.Equals(TaxCalculatorConstant.Yes, StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        continueAttempt = 0;
                        bool isValidInputs = UserInputForTaxCalculation(out double userIncome,
                                                                        out double userInvestment,
                                                                        out double userHouseExpense,
                                                                        out int userAge,
                                                                        out string userGender);

                        if (isValidInputs == false)
                        {
                            Console.WriteLine(Environment.NewLine + TaxCalculatorConstant.MsgAttemptsExhausted + Environment.NewLine);
                        }
                        else
                        {
                            double taxableAmount = TotalTaxCalculator.CalculateTaxableAmount(userIncome, userInvestment, userHouseExpense);
                            double totalTaxAmount = TaxCalForAnyIndividual.TaxForAnyIndividual(taxableAmount, userAge, userGender);

                            Console.WriteLine(Environment.NewLine + TaxCalculatorConstant.Border +
                                              Environment.NewLine + TaxCalculatorConstant.TaxResultHeading +
                                              Environment.NewLine + TaxCalculatorConstant.Border);
                            Console.WriteLine(TaxCalculatorConstant.MsgTaxableAmount.PadRight(TaxCalculatorConstant.RightPadding) + ": " + taxableAmount);
                            Console.WriteLine(TaxCalculatorConstant.MsgPayableTax.PadRight(TaxCalculatorConstant.RightPadding) + ": " + totalTaxAmount +
                                              Environment.NewLine + Environment.NewLine);
                        }
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine(TaxCalculatorConstant.ErrOverflow + ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(TaxCalculatorConstant.ErrIncorrectFormat + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(TaxCalculatorConstant.ErrInvalidDefault + ex.Message);
                    }

                    Console.WriteLine(TaxCalculatorConstant.MsgAskToContinue + Environment.NewLine);
                    continueCondition = ContinueConditionCheck();
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    if (continueAttempt < TaxCalculatorConstant.MaxAttempt)
                    {
                        Console.WriteLine(TaxCalculatorConstant.MsgWentWrong);
                        continueCondition = ContinueConditionCheck();
                        Console.WriteLine();
                        continueAttempt++;
                        continue;
                    }

                    break;
                }
            }

            Console.WriteLine(Environment.NewLine + TaxCalculatorConstant.MsgExit);
            Console.ReadLine();
        }

        /// <summary>
        /// Continue Check Method for Program
        /// </summary>
        /// <returns>User's input for if want to continue or not</returns>
        private static string ContinueConditionCheck()
        {
            string continueInput = TaxCalculatorConstant.Yes;

            try
            {
                continueInput = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(TaxCalculatorConstant.ErrInvalidDefault + ex.Message);
            }

            return continueInput;
        }

        /// <summary>
        /// Takes String input and return valid double value
        /// </summary>
        /// <param name="msgInput">Input Message</param>
        /// <param name="minValue">Min value for validation</param>
        /// <param name="maxValue">Max value for validation</param>
        /// <returns>Valid Double input if input is valid else return -1</returns>
        private static double TakeImputAndValidateDouble(string msgInput, double minValue, double maxValue = double.MaxValue)
        {
            for (int inputAttempt = 0; inputAttempt < TaxCalculatorConstant.MaxAttempt; inputAttempt++)
            {
                Console.Write(msgInput);
                string userInput = Console.ReadLine();
                double validDoubleInput = Utility.DoubleValidation(userInput, out string errorMsg, minValue, maxValue);

                if (string.IsNullOrEmpty(errorMsg) == false)
                {
                    Console.WriteLine(errorMsg + Environment.NewLine);
                    continue;
                }

                return validDoubleInput;
            }

            return -1;
        }

        /// <summary>
        /// Method to take name and validate
        /// </summary>
        /// <returns>valid User Name if input is valid else return null</returns>
        private static string TakeNameAndValidate()
        {
            for (int inputAttempt = 0; inputAttempt < TaxCalculatorConstant.MaxAttempt; inputAttempt++)
            {
                Console.Write(TaxCalculatorConstant.MsgAskName.PadRight(TaxCalculatorConstant.RightPadding) + ": ");
                string userName = Console.ReadLine();
                userName = userName.Trim();

                if (string.IsNullOrEmpty(userName) == true)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgEmptyName + Environment.NewLine);
                    continue;
                }

                // Checks if name contains integer
                if (userName.Any(char.IsDigit) == true)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgIfIntName + Environment.NewLine);
                    continue;
                }

                return userName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Method to take BirthDate as input and return Age of user
        /// </summary>
        /// <returns>Valid User Age if input is valid else return 0</returns>
        private static int TakeBirthAndGivesValidAge()
        {
            for (int inputAttempt = 0; inputAttempt < TaxCalculatorConstant.MaxAttempt; inputAttempt++)
            {
                Console.Write(TaxCalculatorConstant.MsgASkBirthdate.PadRight(TaxCalculatorConstant.RightPadding) + ": ");
                string dateInput = Console.ReadLine();

                // Try Parse Birth date in DateTime
                bool isValidBirthDate = DateTime.TryParseExact(dateInput, TaxCalculatorConstant.BirthDateFormat, CultureInfo.CurrentCulture,
                                        DateTimeStyles.None, out DateTime userBirth);

                if (isValidBirthDate == false)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgInvalidBirth + Environment.NewLine);
                    continue;
                }

                if (userBirth.Equals(null) == true)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgNullBirth + Environment.NewLine);
                    continue;
                }

                // Checks if Birth date is greater than todays date
                if (userBirth > DateTime.Now.Date)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgBirthdateAfterToday + Environment.NewLine);
                    continue;
                }

                // Calculate age of user in year
                int userAge = DateTime.Now.Year - userBirth.Year;

                // Checks if user age is greater than 120 than returns false
                if (userAge > TaxCalculatorConstant.MaxAge)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgAgeGreaterThan120 + Environment.NewLine);
                    continue;
                }

                return userAge;
            }

            return 0;
        }

        /// <summary>
        /// Method to take Gender And validate
        /// </summary>
        /// <returns>Valid User Gender if input is valid else return null</returns>
        private static string TakeGenderAndValidate()
        {
            for (int inputAttempt = 0; inputAttempt < TaxCalculatorConstant.MaxAttempt; inputAttempt++)
            {
                Console.Write(TaxCalculatorConstant.MsgAskGender.PadRight(TaxCalculatorConstant.RightPadding) + ": ");
                string userGender = Console.ReadLine();

                if (string.IsNullOrEmpty(userGender) == true)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgNullGender + Environment.NewLine);
                    continue;
                }

                // If input for user gender is other than M/m, F/f, Male or Female then returns false
                if ((userGender.Equals(TaxCalculatorConstant.MsgStringMale, StringComparison.CurrentCultureIgnoreCase) ||
                     userGender.Equals(TaxCalculatorConstant.MsgStringFemale, StringComparison.CurrentCultureIgnoreCase) ||
                     userGender.Equals(TaxCalculatorConstant.Female, StringComparison.CurrentCultureIgnoreCase) ||
                     userGender.Equals(TaxCalculatorConstant.Male, StringComparison.CurrentCultureIgnoreCase)) == false)
                {
                    Console.WriteLine(TaxCalculatorConstant.MsgWrongGender + Environment.NewLine);
                    continue;
                }

                return userGender;
            }

            return string.Empty;
        }

        /// <summary>
        /// Takes all user Inputs from the User for calculating Tax
        /// </summary>
        /// <param name="userIncome">User's Income</param>
        /// <param name="userInvestment">User's Investment</param>
        /// <param name="userHouseExpense">User's House Expense</param>
        /// <param name="userAge">User's Age</param>
        /// <param name="userGender">User's Gender</param>
        /// <return>True if all inputs are valid else return false</return>
        private static bool UserInputForTaxCalculation(out double userIncome,
                                                       out double userInvestment,
                                                       out double userHouseExpense,
                                                       out int userAge,
                                                       out string userGender)
        {
            userIncome = -1;
            userInvestment = -1;
            userHouseExpense = -1;
            userAge = 0;
            userGender = null;

            Console.WriteLine(TaxCalculatorConstant.HeadingBorder + Environment.NewLine +
                              TaxCalculatorConstant.HeadingContent + Environment.NewLine +
                              TaxCalculatorConstant.HeadingBorder + Environment.NewLine);
            Console.WriteLine(TaxCalculatorConstant.Border + Environment.NewLine +
                              TaxCalculatorConstant.PersonalDetailsHeading + Environment.NewLine +
                              TaxCalculatorConstant.Border);

            // Takes Name Input from User and validate
            string userName = TakeNameAndValidate();

            if (string.IsNullOrEmpty(userName) == true)
            {
                return false;
            }

            // Takes Birth date and calculate valid Age
            userAge = TakeBirthAndGivesValidAge();

            if (userAge.Equals(0) == true)
            {
                return false;
            }

            // Takes Gender Input from user and validate
            userGender = TakeGenderAndValidate();

            if (string.IsNullOrEmpty(userGender) == true)
            {
                return false;
            }

            Console.WriteLine(Environment.NewLine + TaxCalculatorConstant.Border +
                              Environment.NewLine + TaxCalculatorConstant.AccountDetailsHeading +
                              Environment.NewLine + TaxCalculatorConstant.Border);

            // Takes Income as Input from User and validate
            userIncome = TakeImputAndValidateDouble(TaxCalculatorConstant.MsgAskIncome.PadRight(TaxCalculatorConstant.RightPadding) + ": ", 1);

            if (userIncome.Equals(-1) == true)
            {
                return false;
            }

            // Takes Investment as Input from User and validate
            userInvestment = TakeImputAndValidateDouble(TaxCalculatorConstant.MsgAskInvestment.PadRight(TaxCalculatorConstant.RightPadding)
                                                        + ": ", 0, userIncome);

            if (userInvestment.Equals(-1) == true)
            {
                return false;
            }

            if (userIncome - userInvestment == 0)
            {
                Console.WriteLine(TaxCalculatorConstant.MsgAskLoan.PadRight(TaxCalculatorConstant.RightPadding) +
                                  TaxCalculatorConstant.DefaultAllIncomeInvested + Environment.NewLine + Environment.NewLine +
                                  TaxCalculatorConstant.MsgAllIncomeInvested);
                userHouseExpense = 0;
            }
            else
            {
                // Takes User House Loan/Rent as Input from User and validate
                userHouseExpense = TakeImputAndValidateDouble(TaxCalculatorConstant.MsgAskLoan.PadRight(TaxCalculatorConstant.RightPadding)
                                                              + ": ", 0, (userIncome - userInvestment));

                if (userHouseExpense.Equals(-1) == true)
                {
                    return false;
                }
            }

            return true;
        }
    }
}