using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public const int MaxBrightness = 100; 
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }
        public Guid Id { get; protected set; }

        public void ChangeBrightness(int brightness)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot change brightness if the lamp is off");
            }

            if (brightness > MaxBrightness || brightness < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Brightness = brightness;
        }

        public bool IsLampOn()
        {
            return IsOn;
        }

        public abstract void TurnOnOff();
    }
}
