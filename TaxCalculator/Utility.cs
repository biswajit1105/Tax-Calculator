namespace TaxCalculator
{
    /// <summary>
    /// Check Validation for different Data types
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Method to validate double input
        /// </summary>
        /// <param name="input">Input parameter for validation</param>
        /// <param name="errorMsg">Error Message</param>
        /// <param name="minValue">Min Range of expected output</param>
        /// <param name="maxValue">Max Range of expected output</param>
        /// <return>Valid double value if input is valid else return default</return>
        public static double DoubleValidation(string input, out string errorMsg,
                                              double minValue = double.MinValue,
                                              double maxValue = double.MaxValue)
        {
            errorMsg = string.Empty;

            if (string.IsNullOrEmpty(input) == true)
            {
                errorMsg = TaxCalculatorConstant.MsgNullInput;
                return default;
            }

            // Check if input is valid double number or not
            if (double.TryParse(input, out double validDouble) == false)
            {
                errorMsg = TaxCalculatorConstant.ErrNotValidDouble;
                return default;
            }

            // Check if input is less than min value
            if (validDouble < minValue)
            {
                errorMsg = TaxCalculatorConstant.MsgInputGreaterOrEqualTo + minValue;
                return default;
            }

            // Check if input is greater than max value
            if (validDouble > maxValue)
            {
                errorMsg = TaxCalculatorConstant.MsgInputLessOrEqualTo + maxValue;
                return default;
            }

            return validDouble;
        }
    }
}
