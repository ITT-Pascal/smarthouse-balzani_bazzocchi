using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public sealed class EcoLamp: AbstractLamp
    {
        public EcoLamp(string name, Guid id) : base(id, name)
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
                    Intensity = Intensity / 2;
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