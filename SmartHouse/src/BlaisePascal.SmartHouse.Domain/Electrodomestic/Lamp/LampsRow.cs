using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public class LampsRow
    {
        // Properties
        public const int MaxBrightness = 100;
        public string Name { get; private set; }
        public List<LampDesign> LampList { get; private set; }
        public Lamp Lamp { get; set; }
        public EcoLamp EcoLamp { get; set; }

        // Constructor
        public LampsRow(List<LampDesign> lamps, string name)
        {
            Name = name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }
            if (lamps == null)
            {
                throw new ArgumentNullException(nameof(lamps), "LampList cannot be null");
            }

            LampList = new List<LampDesign>();
            foreach (var lamp in lamps)
            {
                if (lamp == null)
                {
                    throw new ArgumentNullException(nameof(lamp));
                }
                LampList.Add(lamp);
            }

           
            Lamp = new Lamp(DateTime.UtcNow, new Random(), Guid.NewGuid());
            EcoLamp = new EcoLamp(DateTime.UtcNow, new Random(), Guid.NewGuid());
        }

        // Switch On/Off Methods
        public void SwitchOn()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].TurnOnOff();
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                LampList[i].Status = DeviceStatus.On;
            }
        }

        public void SwitchOn(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].TurnOnOff();
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                    LampList[i].Status = DeviceStatus.On;
                }
            }
        }

        public void SwitchOn(string name)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Name == name)
                {
                    LampList[i].TurnOnOff();
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                    LampList[i].Status = DeviceStatus.On;
                }
            }
        }
        public void SwitchOff()
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].TurnOnOff();
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                LampList[i].Status = DeviceStatus.Off;
            }
        }

        public void SwitchOff(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList[i].TurnOnOff();
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                    LampList[i].Status = DeviceStatus.Off;
                }
            }
        }

        public void SwitchOff(string name)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Name == name)
                {
                    LampList[i].TurnOnOff();
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                    LampList[i].Status = DeviceStatus.Off;
                }
            }
        }

        //Add/Remove Lamp Methods
        public void AddLamp(LampDesign lamp)
        {
            if (lamp == null)
            {
                throw new ArgumentNullException(nameof(lamp), "Lamp cannot be null");
            }
            if (!(lamp is Lamp))
            {
                throw new ArgumentException("The lamp must be of type Lamp", nameof(lamp));
            }
            LampList.Add(lamp);
            lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }   


        public void AddEcoLamp(LampDesign ecoLamp)
        {
            if (ecoLamp == null)
            {
                throw new ArgumentNullException(nameof(ecoLamp), "EcoLamp cannot be null");
            }
            if (!(ecoLamp is EcoLamp))
            {
                throw new ArgumentException("The lamp must be of type EcoLamp", nameof(ecoLamp));
            }
            LampList.Add(ecoLamp);
            ecoLamp.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void RemoveLamp(Guid id)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                {
                    LampList.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveLamp(string name)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Name == name)
                {
                    LampList.RemoveAt(i);
                    break;
                }
            }
        }
        //Add/Remove Lamp In Position Method
        public void AddLampInPosition(LampDesign lamp, int position)
        {
            if (lamp == null)
            {
                throw new ArgumentNullException(nameof(lamp), "Lamp cannot be null");
            }
           
            if (position < 0 || position > LampList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range");
            }
            LampList.Insert(position, lamp);
            lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void RemoveLampInPosition(int position)
        {
            if (position < 0 || position >= LampList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range");
            }
            LampList.RemoveAt(position);
        }

        // Turn On/Off Methods for All Lamps
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

        // Set Intensity Methods
        public void SetIntensityForAllLamps(int intensity)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList[i].SetIntensity(intensity);
                LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
            }
        }

        public void SetIntensityForLamp(Guid id, int brightness)
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

        public void SetIntensityForLamp(string name, int brightness)
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Name == name)
                {
                    LampList[i].SetIntensity(brightness);
                    LampList[i].LastModifiedAtUtc = DateTime.UtcNow;
                }
            }
        }

        // Search and Sort Methods
        public LampDesign? FindLampWithMaxIntensity()
        {
            LampDesign? maxLamp = null;
            int maxIntensity = -1;
            foreach (var lamp in LampList)
            {
                if (lamp.Intensity > maxIntensity)
                {
                    maxIntensity = lamp.Intensity;
                    maxLamp = lamp;
                }
            }
            return maxLamp;
        }
        public LampDesign? FindLampWithMinIntensity()
        {
            LampDesign? minLamp = null;
            int minIntensity = MaxBrightness + 1;
            foreach (var lamp in LampList)
            {
                if (lamp.Intensity < minIntensity)
                {
                    minIntensity = lamp.Intensity;
                    minLamp = lamp;
                }
            }
            return minLamp;
        }
        public List<LampDesign> FindLampsByIntensityRange(int min, int max)
        {
            List<LampDesign> result = new List<LampDesign>();
            foreach (var lamp in LampList)
            {
                if (lamp.Intensity >= min && lamp.Intensity <= max)
                {
                    result.Add(lamp);
                }
            }
            return result;
        }
        public List<LampDesign> FindAllOn()
        {
            List<LampDesign> result = new List<LampDesign>();
            foreach (var lamp in LampList)
            {
                if (lamp.IsOn)
                {
                    result.Add(lamp);
                }
            }
            return result;
        }
        public List<LampDesign> FindAllOff()
        {
            List<LampDesign> result = new List<LampDesign>();
            foreach (var lamp in LampList)
            {
                if (!lamp.IsOn)
                {
                    result.Add(lamp);
                }
            }
            return result;
        } 
        public LampDesign? FindLampById(Guid id)
        {
            foreach (var lamp in LampList)
            {
                if (lamp.Id == id)
                {
                    return lamp;
                }
            }
            return null;
        }
        public List<LampDesign> SortByIntensity(bool descending)
        {
            if (descending)
            {
                return LampList.OrderByDescending(l => l.Intensity).ToList();
            }
            else
            {
                return LampList.OrderBy(l => l.Intensity).ToList();
            }
        }
    }
}
