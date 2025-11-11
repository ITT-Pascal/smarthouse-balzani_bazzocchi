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

        public List<LampDesign> LampList { get; private set; }
        public Lamp Lamp { get; set; }
        public EcoLamp EcoLamp { get; set; }


        public LampsRow(int numLamp) // costruttore
        {
            LampList = new List<LampDesign>();
            Lamp = new Lamp();
            EcoLamp = new EcoLamp();

            for (int i = 0; i < numLamp; i++)
            {

                LampList.Add(new Lamp());
            }
        }

        public LampsRow()
        {
            LampList = new List<LampDesign>();
            Lamp = new Lamp();
            EcoLamp = new EcoLamp();
        }

        public void AddLamp(LampDesign lamp)
        {
            LampList.Add(lamp);
        }   


        public void AddEcoLamp(LampDesign ecoLamp)
        {
            LampList.Add(ecoLamp);
        }

        public void TurnOnOffAllLamps()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i] is Lamp)
                    LampList[i].TurnOnOff();
            }
        }

        public void TurnOnOffAllEcoLamps()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i] is EcoLamp)
                    LampList[i].TurnOnOff();
            }
        }

        public void TurnOnOffAllDevices()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].TurnOnOff();
            }
        }

        public void TurnOneLampOnOff(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].TurnOnOff();
                }
            }
        }

        public void ChangeBrightnessAllDevices(int brightness)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].ChangeBrightness(brightness);
            }
        }

        public void ChangeBrightnessOneDevice(Guid id, int brightness)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].ChangeBrightness(brightness);
                }
            }
        }

        public bool IsLampOn(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    return LampList[i].IsOn;
                }
            }
            return false;
        }




    }
}
