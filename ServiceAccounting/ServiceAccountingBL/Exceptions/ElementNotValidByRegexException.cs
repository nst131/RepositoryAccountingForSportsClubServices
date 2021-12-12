using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementNotValidByRegexException : Exception
    {
        public const string defaultMessage = "Your element is not valid by Regex";
        public ElementNotValidByRegexException() : base(defaultMessage) { }
        public ElementNotValidByRegexException(string message) : base(message) { }
    }
}
