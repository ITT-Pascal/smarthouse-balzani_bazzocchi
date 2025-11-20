using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: LampDesign
    {
        public const int MaxBrightness = 100;

        public EcoLamp(DateTime createdAtUtc, Random random, Guid id):base (createdAtUtc, random, id) 
        { 
            
        }
       
        public override void TurnOnOff()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On; 
                Intensity = MaxBrightness;
                LastModifiedAtUtc = DateTime.Now;

            }
            else
            {
                Status = DeviceStatus.Off;
                Intensity = 0;
                LastModifiedAtUtc = DateTime.Now;
            }
        }

        public override void SetIntensity(int brightness)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness if the ecolamp is off");
            }

            if (brightness > MaxBrightness || brightness < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Intensity = brightness;
            LastModifiedAtUtc = DateTime.Now;
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