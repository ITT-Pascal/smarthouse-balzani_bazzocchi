using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public class Lamp: LampDesign
    {
        public const int MaxBrightness = 100 ;
        public const int MinBrightness = 0;

        public override int MaxIntensity => MaxBrightness;
        public override int MinIntensity => MinBrightness;

        public Lamp(DateTime createdAtUtc, Random random, Guid guid) : base(createdAtUtc, random, guid)
        {

        }

        
        public override void TurnOnOff()
        {
            base.TurnOnOff();
        }
       

        public override void SetIntensity(int intensity)
        {
            base.SetIntensity(intensity);
        }
        public void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot dimmer if the lamp is off");
            }
            if (Intensity - amount < MinBrightness)
            {
                Intensity = MinBrightness;
            }
            else
            {
                Intensity -= amount;
            }
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public override DeviceStatus LampStatus() 
        {
            return Status;
        }


    }
}
