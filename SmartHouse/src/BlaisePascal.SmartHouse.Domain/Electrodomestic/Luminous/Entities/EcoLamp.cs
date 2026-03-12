using BlaisePascal.SmartHouse.Domain.Abstractions.Status;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities
{
    public sealed class EcoLamp: AbstractLamp
    {
        public EcoLamp(Name name) : base(name)
        {

        }
        public void AutoTurnOff()
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot call AutoTurnOff method if the ecolamp is off");
            }

            if (Status == DeviceStatus.On)
            {
                DateTime _now = DateTime.UtcNow;

                if (_now - CreatedAtUtc > TimeSpan.FromMinutes(60))
                {
                    
                    Intensity = new Intensity(Intensity.Value-25);
                }

                if (_now - CreatedAtUtc > TimeSpan.FromMinutes(120))
                {
                    Toggle();
                }
                LastModifiedAtUtc = DateTime.Now;
            }
        }
    }
}