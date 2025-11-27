using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public abstract class LampDesign
    {
        public Random random {  get; set; }
        public bool IsOn { get; protected set; }
        public int Intensity { get; protected set; }
        public DeviceStatus Status { get; set; }
        public Guid Id { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; set; }

        public abstract int MaxIntensity { get; }
        public abstract int MinIntensity { get; }

        public LampDesign(DateTime createdAtUtc, Random _random, Guid guid)
        {
            random = _random;
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
            IsOn = false;
            Intensity = 0;
            Id = guid;
            Status = DeviceStatus.Off;
        }

        public virtual void TurnOnOff()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                Intensity = MaxIntensity;
                LastModifiedAtUtc = DateTime.UtcNow;         

            }
            else
            {
                Status = DeviceStatus.Off;
                Intensity = 0;
                LastModifiedAtUtc = DateTime.Now;
            }
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
        
        public abstract DeviceStatus LampStatus();
       

       
    



    }
}
