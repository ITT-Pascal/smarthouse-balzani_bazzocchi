using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsRow
    {
        public const int MaxBrightness = 100;
        public string Name { get; private set; }
        public List<LampDesign> LampList { get; private set; }
        public Lamp Lamp { get; set; }
        public EcoLamp EcoLamp { get; set; }


        public LampsRow(int numLamp,string name)
        {
            LampList = new List<LampDesign>();
            Name = name;
            for (int i = 0; i < numLamp; i++)
            {
                LampList.Add(new Lamp(DateTime.UtcNow, new Random(), Guid.NewGuid()));
            }
        }

        public LampsRow()
        {
            LampList = new List<LampDesign>();
            Lamp = new Lamp(DateTime.UtcNow, new Random(), Guid.NewGuid());
            EcoLamp = new EcoLamp(DateTime.UtcNow, new Random(), Guid.NewGuid());
        }

        public void AddLamp(LampDesign lamp)
        {
            LampList.Add(lamp);
            lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }   


        public void AddEcoLamp(LampDesign ecoLamp)
        {
            LampList.Add(ecoLamp);
            ecoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void TurnOnOffAllLamps()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i] is Lamp)
                    LampList[i].TurnOnOff();
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void TurnOnOffAllEcoLamps()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i] is EcoLamp)
                    LampList[i].TurnOnOff();
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void TurnOnOffAllDevices()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].TurnOnOff();
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void TurnOneLampOnOff(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].TurnOnOff();
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                }
            }
        }

        public void ChangeBrightnessAllDevices(int brightness)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].SetIntensity(brightness);
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void ChangeBrightnessOneDevice(Guid id, int brightness)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].SetIntensity(brightness);
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                }
            }
        }
    }
}
