using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lamp
{
    public class EcoLamp: LampDesign
    {
        public const int MaxBrightness = 100;
        public const int MinBrightness = 0;

        public override int MaxIntensity => MaxBrightness;
        public override int MinIntensity => MinBrightness;

        public EcoLamp(DateTime createdAtUtc, Random random, Guid id):base (createdAtUtc, random, id) 
        { 
            
        }

        

        public override void SetIntensity(int intensity)
        {
            base.SetIntensity(intensity);
        }

        public override DeviceStatus LampStatus()
        {
            return Status;
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
                    TurnOnOff();
                }
                LastModifiedAtUtc = DateTime.Now;
            }


        }
    }
}