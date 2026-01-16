using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public class Lamp: AbstractLamp
    {
        public Lamp(  Guid id, string name) : base(id, name)
        {

        }
        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot dimmer if the lamp is off");
            }
            if (Intensity - amount < MinIntensity)
            {
                Intensity = MinIntensity;
            }
            else
            {
                Intensity -= amount;
            }
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
