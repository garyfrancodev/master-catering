using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class DiagnosisDetails
    {
        public string Value { get; }

        public DiagnosisDetails(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Diagnosis details cannot be null or empty.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is DiagnosisDetails other)
                return Value == other.Value;

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }

}
