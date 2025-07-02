using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceAccountingDA.Models
{
    public class Enumeration : IComparable, IEquatable<Enumeration>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        protected Enumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString() => this.Name;

        public static IEnumerable<T> GetAll<T>()
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if ((obj is not Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = this.GetType() == obj.GetType();
            var valueMatches = this.Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public virtual bool Equals(Enumeration other)
        {
            return this.Equals((object)other);
        }


        public override int GetHashCode() => this.Id.GetHashCode();

        public static T FromValue<T>(int value)
            where T : Enumeration
        {
            return Parse<T, int>(value, "value", item => item.Id == value);
        }

        public static T FromDisplayName<T>(string displayName)
            where T : Enumeration
        {
            return Parse<T, string>(
                displayName,
                "display name",
                item => item.Name.Equals(displayName, StringComparison.OrdinalIgnoreCase));
        }

        private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate)
            where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            return matchingItem ??
                   throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
        }

        public int CompareTo(object obj) => this.Id.CompareTo(((Enumeration)obj).Id);
    }
}
