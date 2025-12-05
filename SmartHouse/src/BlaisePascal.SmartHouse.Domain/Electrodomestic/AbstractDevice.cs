using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic
{
    public abstract class AbstractDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DeviceStatus Status { get; set; }

        protected AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
        }

        public virtual void TurnOnOff()
        {
            if (Status == DeviceStatus.Off)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Off;
        }

    }
}
