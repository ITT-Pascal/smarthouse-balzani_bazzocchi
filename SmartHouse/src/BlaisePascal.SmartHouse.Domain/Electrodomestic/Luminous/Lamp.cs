
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous
{
    public sealed class Lamp: AbstractLamp
    {
        public Lamp(Guid id, string name) : base(id, name)
        {

        }
        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot dimmer if the lamp is off");
            }
            if (Intensity.Value - amount < MinIntensity.Value)
            {
                Intensity = MinIntensity;
            }
            else
            {
                Intensity = new Intensity(Intensity.Value - amount);
            }
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
