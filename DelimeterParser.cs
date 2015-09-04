using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class DelimeterParser
    {
        private const string DelimeteDefinitionStart = "//";
        private const string DelimeterDefinitionTerminator = "\n";
        private const char DelimeterSeparator = ']';
        private readonly List<string> _delimeters;
        public DelimeterParser() { _delimeters = new List<string> {",", "\n"}; }

        public string[] GetDelimeters(string numbers)
        {
            if (DelimeterSet(numbers))
                _delimeters.AddRange(GetDelimeterDefinitions(numbers).Select(StripEroniousChars));
            return _delimeters.ToArray();
        }

        private IEnumerable<string> GetDelimeterDefinitions(string numbers)
        {
            var delimeterOffset = DelimeteDefinitionStart.Length;
            var delimeterDefinitionString = numbers.Substring(Offset(numbers, DelimeteDefinitionStart) + delimeterOffset, Offset(numbers, DelimeterDefinitionTerminator) - delimeterOffset);
            return delimeterDefinitionString.Split(DelimeterSeparator);
        }

        private string StripEroniousChars(string value) { return value.Replace("[", string.Empty).Replace("]", string.Empty); }
        private int Offset(string text, string searchValue) { return text.IndexOf(searchValue, StringComparison.Ordinal); }
        private bool DelimeterSet(string numbers) { return numbers.StartsWith(DelimeteDefinitionStart); }
    }
}