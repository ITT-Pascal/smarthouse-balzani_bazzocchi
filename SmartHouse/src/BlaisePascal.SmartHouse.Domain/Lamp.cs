using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampDesign
    {
        public const int MaxBrightness = 100 ;
        public const int MinBrightness = 0;

        public Lamp(DateTime createdAtUtc, Random random, Guid guid) : base(createdAtUtc, random, guid)
        {

        }

        
        public override void TurnOnOff()
        {
            if (IsOn == false)
            {
                IsOn = true;
                Intensity = MaxBrightness;
            } else
            {
                IsOn = false;
                Intensity = 0;
            }
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public override void SetIntensity(int intensity)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness if the lamp is off");
            }

            if (intensity > MaxBrightness || intensity  < MinBrightness)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Intensity = intensity;
            LastModifiedAtUtc = DateTime.UtcNow;
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
