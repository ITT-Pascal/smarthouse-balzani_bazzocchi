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
        public Intensity Intensity { get; protected set; }
        public Intensity MaxIntensity { get; protected set; }
        public Intensity MinIntensity { get; protected set; }
        public AbstractLamp(Guid id, Name name) : base(name, id)
        {
            MinIntensity = new Intensity(0);
            MaxIntensity = new Intensity(100);
            Intensity = MinIntensity;
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
        public virtual void SetIntensity(Intensity intensity)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness if the ecolamp is off");
            }

            if ( intensity.Value > MaxIntensity.Value || intensity.Value < MinIntensity.Value)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Intensity = intensity;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
