using System;

namespace StringCalculator
{
    public class NumberValidator
    {
        private const int MaximumValue = 1000;
        public int Validate(int number) { return ValidateMaximumValue(ValidateMinusNumbers(number)); }
        private int ValidateMaximumValue(int number) { return number > MaximumValue ? 0 : number; }
        
        private int ValidateMinusNumbers(int number)
        {
            if (number < 0)
                throw new Exception("negatives not allowed");
            return number;
        }
    }
}