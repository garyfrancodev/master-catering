using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class FullName
    {
        public string Value { get; }

        public FullName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be null or empty.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is FullName other)
                return Value == other.Value;

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }

}
