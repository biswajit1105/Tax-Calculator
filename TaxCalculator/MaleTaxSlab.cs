namespace TaxCalculator
{
    /// <summary>
    /// Sets Tax Slab Ranges for Male
    /// </summary>
    internal class MaleTaxSlab : TotalTaxCalculator
    {
        /// <summary>
        /// Constructor for setting Tax Slab Ranges for Male 
        /// </summary>
        internal MaleTaxSlab()
        {
            base.NoTaxRange = TaxCalculatorConstant.MaleNoTaxRange;
            base.Tax10Range = TaxCalculatorConstant.MaleTax10Range;
            base.Tax20Range = TaxCalculatorConstant.MaleTax20Range;
        }
    }
}
