using BlaisePascal.SmartHouse.Domain.Abstractions;
using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities
{
    public sealed class TwoDeviceLamp: AbstractDevice
    {
        public Lamp Lamp { get; private set; }
        public EcoLamp EcoLamp { get; private set; }
        public TwoDeviceLamp(Name name, Lamp lamp, EcoLamp ecoLamp):base(name)
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
        public void SetLampIntensity(Intensity intensity)
        {
            Lamp.SetIntensity(intensity);
        }
        public void SetEcoLampIntensity(Intensity intensity)
        {
            EcoLamp.SetIntensity(intensity);
        }
        public void SetBothIntensity(Intensity intensity)
        {
            Lamp.SetIntensity(intensity);
            EcoLamp.SetIntensity(intensity);
        }
    }
}
