using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {
        public const int MaxBrightness = 100;

        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        public DateTime TimeLampOn { get; private set; }

        public EcoLamp(DateTime _timeLampOn)
        {
            
            TimeLampOn = _timeLampOn.ToUniversalTime();
            IsOn = true;
            Brightness = 0;
        }
       

        public EcoLamp()               //overload del costruttore
        {
            IsOn = false;
            Brightness = 0;
        }

        public void TurnOnOff()
        {
            if (IsOn == false)
            {
                IsOn = true;
                TimeLampOn = DateTime.UtcNow;
                Brightness = MaxBrightness;

            }
            else
            {
                IsOn = false;
                Brightness = 0;
            }
        }

        public void ChangeBrightness(int brightness)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot change brightness if the ecolamp is off");
            }

            if (brightness > MaxBrightness || brightness < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Brightness = brightness;
        }

        public bool IsEcoLampOn()
        {
            return IsOn;
        }

        public void AutoTurnOff()
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot call AutoTurnOff method if the ecolamp is off");
            }

            if (IsOn == true)
            {
                DateTime _now = DateTime.UtcNow;
                
                

                if (_now - TimeLampOn > TimeSpan.FromMinutes(60))
                {
                    Brightness = Brightness / 2;
                }

                if (_now - TimeLampOn > TimeSpan.FromMinutes(120))
                {
                    TurnOnOff();
                }
            }


        }
    }
}