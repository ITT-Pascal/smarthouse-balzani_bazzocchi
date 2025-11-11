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
    public class TwoDeviceLamp  // prova

    {
        public const int MaxBrightness = 100;
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        public Lamp Lamp { get; private set; }
        public EcoLamp EcoLamp { get; private set; }

        public TwoDeviceLamp(int brightness, Lamp lamp, EcoLamp ecoLamp)
        {
            Brightness = brightness;
            Lamp =  lamp; //?
            EcoLamp = ecoLamp;
            IsOn = false;
        }

        public TwoDeviceLamp() 
        {
            Brightness = 0;
            Lamp = new Lamp();
            EcoLamp = new EcoLamp();
            IsOn = false;
        }


        public void TurnOnOffLamp()
        {
            Lamp.TurnOnOff();
        }

        public void TurnOnOffEcoLamp()
        {
            EcoLamp.TurnOnOff();
        }

        public void TurnOnOffBoth()
        {
            EcoLamp.TurnOnOff();
            Lamp.TurnOnOff();
        }

        public bool IsLampOn()
        {
            return Lamp.IsLampOn();
        }

        public bool IsEcoLampOn()
        {
            return EcoLamp.IsEcoLampOn();
        }

        public void ChangeLampBrightness(int newLampBrightness)
        {
            Lamp.ChangeBrightness(newLampBrightness);
        }

        public void ChangeEcoLampBrightness(int newEcoLampBrightness)
        {
            EcoLamp.ChangeBrightness(newEcoLampBrightness);
        }

        public void ChangeEcoLampAndLampBrightness(int newBrightness)
        {
            Lamp.ChangeBrightness(newBrightness);
            EcoLamp.ChangeBrightness(newBrightness);
        }
    }
}
