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
        public int MaxIntensity = 100;
        public int MinIntensity = 0;
        public Intensity(int value)
        {
            if (value < MinIntensity || value > MaxIntensity)
                throw new ArgumentOutOfRangeException(nameof(value), "Intensity must be between 0 and 100.");
            Value = value;
        }
    }
}
