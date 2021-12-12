using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementNullReferenceException : Exception
    {
        public const string defaultMessage = "Element is null";
        public ElementNullReferenceException() : base(defaultMessage) { }
        public ElementNullReferenceException(string message) : base(message) { }
    }
}
