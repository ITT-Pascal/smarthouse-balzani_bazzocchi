using BlaisePascal.SmartHouse.Domain.Abstractions;
using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public class TwoDeviceLamp: AbstractDevice
    {
        public Lamp Lamp { get; private set; }
        public EcoLamp EcoLamp { get; private set; }
        public TwoDeviceLamp(string name, Lamp lamp, EcoLamp ecoLamp, Guid id):base(name, id)
        {
            Lamp = lamp;
            EcoLamp = ecoLamp;
        }
        public void ToggleLamp()
        {
            Lamp.Toggle();
        }
        public void ToggleEco()
        {
            EcoLamp.Toggle();
        }
        public void ToggleBoth()
        {
            EcoLamp.Toggle();
            Lamp.Toggle();
        }
        public void SetLampIntensity(int intensity)
        {
            Lamp.SetIntensity(intensity);
        }
        public void SetEcoLampIntensity(int intensity)
        {
            EcoLamp.SetIntensity(intensity);
        }
        public void SetBothIntensity(int intensity)
        {
            Lamp.SetIntensity(intensity);
            EcoLamp.SetIntensity(intensity);
        }
    }
}
