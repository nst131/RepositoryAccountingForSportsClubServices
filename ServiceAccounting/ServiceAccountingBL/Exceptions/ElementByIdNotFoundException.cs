using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementByIdNotFoundException : Exception
    {
        public const string defaultMessage = "Element not found by Id";
        public ElementByIdNotFoundException() : base(defaultMessage) { }
        public ElementByIdNotFoundException(string message) : base(message) { }
    }
}
