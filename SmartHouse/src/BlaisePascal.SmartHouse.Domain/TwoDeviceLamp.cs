using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoDeviceLamp

    {
        public const int MaxBrightness = 100;
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        public Lamp _lamp { get; private set; }
        public EcoLamp _ecoLamp { get; private set; }

        public TwoDeviceLamp(int brightness, Lamp lamp, EcoLamp ecoLamp)
        {
            Brightness = brightness;
            this._lamp = lamp ?? new Lamp();
            this._ecoLamp = ecoLamp ?? new EcoLamp();
            IsOn = false;
        }

        public TwoDeviceLamp()
        {
            Brightness = 0;
            _lamp = new Lamp();
            _ecoLamp = new EcoLamp();
            IsOn = false;
        }


        public void TurnOnOffLamp()
        {
            _lamp.TurnOnOff();
        }

        public void TurnOnOffEcoLamp()
        {
            _ecoLamp.TurnOnOff();
        }

        public void TurnOnOffBoth()
        {
            _ecoLamp.TurnOnOff();
            _lamp.TurnOnOff();
        }

        public bool IsLampOn()
        {
            return _lamp.IsLampOn();
        }

        public bool IsEcoLampOn()
        {
            return _ecoLamp.IsEcoLampOn();
        }

        public void ChangeLampBrightness(int NewLampBrightness)
        {
            _lamp.ChangeBrightness(NewLampBrightness);
        }

        public void ChangeEcoLampBrightness(int NewEcoLampBrightness)
        {
            _ecoLamp.ChangeBrightness(NewEcoLampBrightness);
        }

        public void ChangeEcoLampAndLampBrightness(int NewBrightness)
        {
            _lamp.ChangeBrightness(NewBrightness);
            _ecoLamp.ChangeBrightness(NewBrightness);
        }
    }
}
