using System;

namespace ServiceAccountingBL.Exceptions
{
    public class ElementCannotbeConverted : Exception
    {
        public const string DefaultMessage = "Element can not converted";
        public ElementCannotbeConverted() : base(DefaultMessage) { }
        public ElementCannotbeConverted(string message) : base(message){}
    }
}
