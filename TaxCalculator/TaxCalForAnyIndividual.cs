using System;

namespace TaxCalculator
{
    /// <summary>
    /// Calculate Total Tax
    /// </summary>
    internal class TaxCalForAnyIndividual
    {
        /// <summary>
        /// Method to Calculate Total Tax Amount
        /// </summary>
        /// <param name="taxableAmount">Taxable Amount</param>
        /// <param name="userAge">User's Age</param>
        /// <param name="userGender">User's Gender</param>
        /// <returns>Total Tax Amount</returns>
        internal static double TaxForAnyIndividual(double taxableAmount, int userAge, string userGender)
        {
            double totalTax = 0;

            if (userAge >= TaxCalculatorConstant.SeniorAgeLimit)
            {
                SeniorCitizenTaxSlab seniorCitizen = new SeniorCitizenTaxSlab();
                totalTax = seniorCitizen.CalculateTotalTax(taxableAmount);
            }
            else if (userGender.Equals(TaxCalculatorConstant.MsgStringFemale, StringComparison.CurrentCultureIgnoreCase) ||
                     userGender.Equals(TaxCalculatorConstant.Female, StringComparison.CurrentCultureIgnoreCase))
            {
                FemaleTaxSlab female = new FemaleTaxSlab();
                totalTax = female.CalculateTotalTax(taxableAmount);
            }
            else if (userGender.Equals(TaxCalculatorConstant.MsgStringMale, StringComparison.CurrentCultureIgnoreCase) ||
                     userGender.Equals(TaxCalculatorConstant.Male, StringComparison.CurrentCultureIgnoreCase))
            {
                MaleTaxSlab male = new MaleTaxSlab();
                totalTax = male.CalculateTotalTax(taxableAmount);
            }

            return totalTax;
        }
    }
}