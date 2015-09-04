using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly DelimeterParser _delimeterParser;
        private readonly NumberValidator _numberValidator;

        public Calculator(DelimeterParser delimeterParser, NumberValidator numberValidator)
        {
            _delimeterParser = delimeterParser;
            _numberValidator = numberValidator;
        }

        public int Add(string numbers) { return GetNumbers(numbers).Sum(); }
        private IEnumerable<string> GetNumberStrings(string numbers) { return numbers.Split(_delimeterParser.GetDelimeters(numbers), StringSplitOptions.None); }

        private IEnumerable<int> GetNumbers(string numberStrings)
        {
            return GetNumberStrings(numberStrings).Select(numberString => _numberValidator.Validate(ParseNumber(numberString)));
        }

        private int ParseNumber(string numberString)
        {
            int value;
            int.TryParse(numberString, out value);
            return value;
        }
    }
}