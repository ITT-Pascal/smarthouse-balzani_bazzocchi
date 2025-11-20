using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
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

        public abstract void TurnOnOff();
        public abstract void SetIntensity(int brightness);
        public abstract DeviceStatus LampStatus();
       

       
    



    }
}
