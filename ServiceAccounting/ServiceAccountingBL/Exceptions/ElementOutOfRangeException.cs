using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementOutOfRangeException : Exception
    {
        public const string defaultMessage = "Element Out Of Range";
        public ElementOutOfRangeException() : base(defaultMessage) { }
        public ElementOutOfRangeException(string message) : base(message) { }
    }
}
