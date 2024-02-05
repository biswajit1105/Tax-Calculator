namespace TaxCalculator
{
    /// <summary>
    /// Calculation of tax calculator
    /// </summary>
    internal class TotalTaxCalculator
    {
        /// <summary>
        /// Property to Set No Tax Range
        /// </summary>
        internal int NoTaxRange { get; set; }

        /// <summary>
        /// Property to Set Upper Limit of 10 Percent Tax Slab
        /// </summary>
        internal int Tax10Range { get; set; }

        /// <summary>
        /// Property to Set Upper Limit of 20 Percent Tax Slab
        /// </summary>
        internal int Tax20Range { get; set; }

        /// <summary>
        /// Calculate Taxable Amount
        /// </summary>
        /// <param name="userIncome">User's Income</param>
        /// <param name="userInvestment">User's Investment</param>
        /// <param name="userHouseExpense">User's House Loan\Rent</param>
        /// <returns>Taxable Amount</returns>
        internal static double CalculateTaxableAmount(double userIncome, double userInvestment, double userHouseExpense)
        {
            // Calculate Valid investment, up to 100000 rupees is valid investment
            double userValidInvestment = (userInvestment < TaxCalculatorConstant.ValidInvestment) ? userInvestment : TaxCalculatorConstant.ValidInvestment;

            // Calculates 20% of total income
            double income20Percent = userIncome * TaxCalculatorConstant.Percent20;

            // Calculates 80% of House Loan/Rent
            double homeLoan80Percent = userHouseExpense * TaxCalculatorConstant.Percent80;

            // calculates less amount out of 20 percent of userIncome and 80 Percent of UserHouse Expense
            double nonTaxableAmount = (income20Percent < homeLoan80Percent) ? income20Percent : homeLoan80Percent;

            double taxableAmount = userIncome - (nonTaxableAmount + userValidInvestment);
            return taxableAmount;
        }

        /// <summary>
        /// Calculate Total Tax Amount
        /// </summary>
        /// <param name="taxableAmount">Taxable Amount</param>
        /// <returns>Total Tax Amount</returns>
        internal double CalculateTotalTax(double taxableAmount)
        {
            double totalTax = 0;

            if (NoTaxRange < taxableAmount && taxableAmount <= Tax10Range)
            {
                // 10 percent Tax on amount between No tax range and taxable amount
                totalTax += (taxableAmount - NoTaxRange) * TaxCalculatorConstant.Percent10;
            }
            else if (Tax10Range < taxableAmount && taxableAmount <= Tax20Range)
            {
                // 10 percent Tax on amount between No tax range to 300000
                totalTax += (Tax10Range - NoTaxRange) * TaxCalculatorConstant.Percent10;

                // 20 percent Tax on amount between 300000 and taxable amount
                totalTax += (taxableAmount - Tax10Range) * TaxCalculatorConstant.Percent20;
            }
            else if (taxableAmount > Tax20Range)
            {
                // 20 percent of (500000 - 300000)
                totalTax += (Tax20Range - Tax10Range) * TaxCalculatorConstant.Percent20;

                // 10 percent Tax on amount between No tax range to 300000
                totalTax += (Tax10Range - NoTaxRange) * TaxCalculatorConstant.Percent10;

                // 20 percent Tax on amount between Taxable amount and 500000
                totalTax += (taxableAmount - Tax20Range) * TaxCalculatorConstant.Percent30;
            }

            return totalTax;
        }
    }
}