using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects
{
    public record Intensity
    {
        public int Value { get; init; }
        public Intensity(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Intensity must be between 0 and 100.");
            Value = value;
        }
    }
}
