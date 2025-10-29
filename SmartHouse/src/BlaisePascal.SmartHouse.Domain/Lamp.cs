using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public Boolean _isOn = false;

        public void TurnOnOff()
        {
            if (_isOn == false)
            {
                _isOn = true;
            } else
            {
                _isOn = false;
            }
        }

        public Boolean IsOn()
        {
            return _isOn;
        }
    }
}
