using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementBindOneToOneException : Exception
    {
        public const string DefaultMessage = "Element Bind One To One";
        public ElementBindOneToOneException() : base(DefaultMessage) { }
        public ElementBindOneToOneException(string message) : base(message) { }
    }
}
