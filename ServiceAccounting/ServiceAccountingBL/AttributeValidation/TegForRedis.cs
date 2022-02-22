using System;

namespace ServiceAccountingBL.AttributeValidation
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    public class TegForRedis : Attribute
    {
        public string GetKeyTeg { get; }

        public TegForRedis(string key)
        {
            this.GetKeyTeg = key;
        }
    }
}
