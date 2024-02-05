namespace TaxCalculator
{
    /// <summary>
    /// Sets Tax Slab Ranges for Female
    /// </summary>
    internal class FemaleTaxSlab : TotalTaxCalculator
    {
        /// <summary>
        /// Constructor for setting Tax Slab Range for Female 
        /// </summary>
        internal FemaleTaxSlab()
        {
            base.NoTaxRange = TaxCalculatorConstant.FemaleNoTaxRange;
            base.Tax10Range = TaxCalculatorConstant.FemaleTax10Range;
            base.Tax20Range = TaxCalculatorConstant.FemaleTax20Range;
        }
    }
}
