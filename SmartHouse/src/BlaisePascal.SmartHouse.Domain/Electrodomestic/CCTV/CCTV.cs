using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV
{
    public class CCTV: AbstractDevice
    {
        public bool NightVision { get; set; }
        TimeOnly StartOfDay;
        TimeOnly StartOfNight;
        
        public CCTV(string name, Guid id): base(name, id)
        {
            StartOfDay = new TimeOnly(21, 30);
            StartOfNight = new TimeOnly(7, 30);
            TimeOnly Now = new TimeOnly(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute);
            if (Now == StartOfDay)
                NightVision = false;
            if (Now == StartOfNight)
                NightVision = true;
        }

        public void SwitchDayNightMode()
        {
            TimeOnly Now = new TimeOnly(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute);
            if(Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot switch day/night mode.");
            if (Status == DeviceStatus.On)
            {
                if (Now == StartOfDay)
                    NightVision = false;
                if (Now == StartOfNight)
                    NightVision = true;
            }
        }
    }
}
