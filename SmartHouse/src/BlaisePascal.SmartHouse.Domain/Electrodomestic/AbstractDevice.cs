using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
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
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; set; }
        public Random Random { get; set; }

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
                LastModifiedAtUtc = DateTime.UtcNow;
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
        public virtual void Open()
        {
            Status = DeviceStatus.Open;
        }
        public virtual void Close()
        {
            Status = DeviceStatus.Close;
        }
        public virtual DeviceStatus GetStatus()
        {
            return Status;
        }
    }
}
