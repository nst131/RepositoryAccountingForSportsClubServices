using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementNotValidByRegexException : Exception
    {
        public const string DefaultMessage = "Your element is not valid by Regex";
        public ElementNotValidByRegexException() : base(DefaultMessage) { }
        public ElementNotValidByRegexException(string message) : base(message) { }
    }
}
