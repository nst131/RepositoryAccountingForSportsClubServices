using System;
using RedisLibrary.Models;

namespace RedisLibrary.Attributes
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
