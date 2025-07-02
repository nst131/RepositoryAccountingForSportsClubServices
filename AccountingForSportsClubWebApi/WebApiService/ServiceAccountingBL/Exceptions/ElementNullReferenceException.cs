using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementNullReferenceException : Exception
    {
        public const string DefaultMessage = "Element is null";
        public ElementNullReferenceException() : base(DefaultMessage) { }
        public ElementNullReferenceException(string message) : base(message) { }
    }
}
