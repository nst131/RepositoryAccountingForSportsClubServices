using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementNotAssignException : Exception
    {
        public const string defaultMessage = "Element was not assigned";
        public ElementNotAssignException() : base(defaultMessage) { }
        public ElementNotAssignException(string message) : base(message) { }
    }
}
