using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractDevice: ISwitchable
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }
        public Random Random { get; protected set; }

        protected AbstractDevice(string name, Guid id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
            Random = new Random();
            Id = id;
            Name = name;
            Status = DeviceStatus.Off;
        }
        public virtual void Toggle()
        {
            if(Status == DeviceStatus.On)
            {
                SwitchOff();
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else if(Status == DeviceStatus.Off)
            {
                SwitchOn();
            }
        }
        public virtual void SwitchOn()
        {
            Status = DeviceStatus.On;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            Status = DeviceStatus.Off;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public virtual DeviceStatus GetStatus()
        {
            return Status;
        }
    }
}
