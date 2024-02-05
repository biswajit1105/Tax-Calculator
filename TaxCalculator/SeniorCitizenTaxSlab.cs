namespace TaxCalculator
{
    /// <summary>
    /// Sets Tax Slab Ranges for Senior Citizen
    /// </summary>
    internal class SeniorCitizenTaxSlab : TotalTaxCalculator
    {
        /// <summary>
        /// Constructor for setting Tax Slab Range for Senior Citizen
        /// </summary>
        internal SeniorCitizenTaxSlab()
        {
            base.NoTaxRange = TaxCalculatorConstant.SeniorNoTaxRange;
            base.Tax10Range = TaxCalculatorConstant.SeniorTax10Range;
            base.Tax20Range = TaxCalculatorConstant.SeniorTax20Range;
        }
    }
}