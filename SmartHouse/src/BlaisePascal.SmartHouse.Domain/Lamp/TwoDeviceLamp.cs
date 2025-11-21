using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlaisePascal.SmartHouse.Domain.Lamp
{
    public class TwoDeviceLamp

    {
        public const int MaxBrightness = 100;
        public int Brightness { get; private set; }
        public Lamp Lamp { get; private set; }
        public EcoLamp EcoLamp { get; private set; }

        public TwoDeviceLamp(Lamp lamp, EcoLamp ecoLamp)
        {
            Brightness = MaxBrightness;
            Lamp = lamp;
            EcoLamp = ecoLamp;

        }

        public void TurnOnOffLamp()
        {
            Lamp.TurnOnOff();
            Lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void TurnOnOffEcoLamp()
        {
            EcoLamp.TurnOnOff();
            EcoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void TurnOnOffBoth()
        {
            EcoLamp.TurnOnOff();
            Lamp.TurnOnOff();
            Lamp.LastModifiedAtUtc = DateTime.UtcNow;
            EcoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public DeviceStatus LampStatus()
        {
            return Lamp.LampStatus();
        }

        public DeviceStatus EcoLampStatus()
        {
            return EcoLamp.LampStatus();
        }

        public void ChangeLampBrightness(int newLampBrightness)
        {
            Lamp.SetIntensity(newLampBrightness);
            Lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void ChangeEcoLampBrightness(int newEcoLampBrightness)
        {
            EcoLamp.SetIntensity(newEcoLampBrightness);
            EcoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void ChangeEcoLampAndLampBrightness(int newBrightness)
        {
            Lamp.SetIntensity(newBrightness);
            EcoLamp.SetIntensity(newBrightness);
            Lamp.LastModifiedAtUtc = DateTime.UtcNow;
            EcoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
