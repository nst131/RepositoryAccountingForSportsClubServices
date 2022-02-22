using ServiceAccountingUI.BaseModels;
using System;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class ViewOperation : Attribute
    {
        public Operation GetOperation { get; }

        public ViewOperation(Operation operation)
        {
            this.GetOperation = operation;
        }
    }
}
