using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: LampDesign
    {
        public DateTime TimeLampOn { get; private set; }

        public EcoLamp() { }

        public EcoLamp(DateTime timeLampOn, Guid guid, string lampName)
        {
            TimeLampOn = timeLampOn.ToUniversalTime();
            IsOn = true;
            Brightness = 0;
            Id = guid;
            LampName = lampName;
        }

        public EcoLamp(string lampName)               //overload del costruttore
        {

            Brightness = 0;
            IsOn = false;
            Id = new Guid();
            LampName = lampName;
        }

        public override void TurnOnOff()
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
        
        public override bool IsLampOn()
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