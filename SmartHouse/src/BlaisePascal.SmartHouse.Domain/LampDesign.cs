using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class LampDesign
    {
        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }

        public abstract void TurnOnOff();
        public abstract void ChangeBrightness(int brightness);
        public abstract bool IsLampOn();
    



    }
}
