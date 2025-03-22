using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PlanDuration
    {
        public int Value { get; }

        public PlanDuration(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Duration must be greater than zero.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is PlanDuration other)
                return Value == other.Value;

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"{Value} days";
    }

}
