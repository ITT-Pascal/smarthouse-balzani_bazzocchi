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
        public const int MaxBrightness = 100; //foca
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        private Random Random { get; set; }
        public Guid Id { get; private set; }

        protected AbstractLamp(Random random, Guid guid, int brightness)
        {
            Brightness = brightness;
            Random = random;
            Id = guid;
        }

        protected AbstractLamp()               // protected: accessibile solo alla classe e alle deri
        {
            Brightness = 0;
            IsOn = false;
            Id = new Guid();
        }

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
