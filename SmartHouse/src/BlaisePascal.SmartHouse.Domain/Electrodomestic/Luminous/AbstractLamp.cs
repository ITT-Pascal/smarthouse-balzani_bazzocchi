using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous
{
    public abstract class AbstractLamp : AbstractDevice
    {
        public int Intensity { get; protected set; }
        public const int MaxIntensity = 100;
        public const int MinIntensity = 0;
        public AbstractLamp(Guid id, string name) : base(name, id)
        {

        }
        public override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = MaxIntensity;
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = MinIntensity;
        }
        public virtual void SetIntensity(int intensity)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness if the ecolamp is off");
            }

            if (intensity > MaxIntensity || intensity < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Intensity = intensity;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
