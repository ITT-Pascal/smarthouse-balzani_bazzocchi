namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp
{
    public class LampsRow: AbstractDevice
    {
        // Properties
        public List<LampDesign> lamps { get; private set; }

        // Constructor
        public LampsRow(string name, Guid id):base(name, id)
        {
            lamps = new List<LampDesign>();
        }

        // Switch On/Off Methods
        public override void SwitchOn()
        {
            base.SwitchOn();
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].SwitchOn();
            }
        }

        public void SwitchOn(Guid id)
        {
            base.SwitchOn();
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Id == id)
                {
                    lamps[i].SwitchOn();
                }
            }
        }

        public void SwitchOn(string name)
        {
            base.SwitchOn();
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Name == name)
                {
                    lamps[i].SwitchOn();
                }
            }
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].SwitchOff();
            }
        }

        public void SwitchOff(Guid id)
        {
            base.SwitchOff();
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Id == id)
                {
                    lamps[i].SwitchOff();
                }
            }
        }

        public void SwitchOff(string name)
        {
            base.SwitchOff();
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Name == name)
                {
                    lamps[i].SwitchOff();
                }
            }
        }

        //Add/Remove Lamp Methods
        public void AddLamp(LampDesign lampDevice)
        {
            if (lampDevice == null)
            {
                throw new ArgumentNullException(nameof(lampDevice), "Lamp cannot be null");
            }
            if (!(lampDevice is Lamp))
            {
                throw new ArgumentException("The lamp must be of type Lamp", nameof(lampDevice));
            }
            lamps.Add(lampDevice);
            lampDevice.LastModifiedAtUtc = DateTime.UtcNow;
        }   


        public void AddEcoLamp(LampDesign lampDevice)
        {
            if (lampDevice == null)
            {
                throw new ArgumentNullException(nameof(lampDevice), "EcoLamp cannot be null");
            }
            if (!(lampDevice is EcoLamp))
            {
                throw new ArgumentException("The lamp must be of type EcoLamp", nameof(lampDevice));
            }
            lamps.Add(lampDevice);
            lampDevice.LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void RemoveLampDevice(Guid id)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Id == id)
                {
                    lamps.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveLampDevice(string name)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Name == name)
                {
                    lamps.RemoveAt(i);
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
           
            if (position < 0 || position > lamps.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range");
            }
            lamps.Insert(position, lamp);
            lamp.LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void RemoveLampInPosition(int position)
        {
            if (position < 0 || position >= lamps.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range");
            }
            lamps.RemoveAt(position);
        }

        // Turn On/Off Methods for All Lamps
        public void ToggleAllLamps()
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i] is Lamp)
                    lamps[i].Toggle();
            }
        }

        public void ToggleAllEcoLamps()
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i] is EcoLamp)
                    lamps[i].Toggle();
            }
        }

        public void ToggleAll()
        {
            base.Toggle();
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].Toggle();
            }
        }

        // Set Intensity Methods
        public void SetIntensityForAllLamps(int intensity)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].SetIntensity(intensity);
            }
        }

        public void SetIntensityForLamp(Guid id, int brightness)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Id == id)
                {
                    lamps[i].SetIntensity(brightness);
                }
            }
        }

        public void SetIntensityForLamp(string name, int brightness)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                if (lamps[i].Name == name)
                {
                    lamps[i].SetIntensity(brightness);
                }
            }
        }

        // Search and Sort Methods
        public LampDesign? FindLampWithMaxIntensity()
        {
            LampDesign? maxLamp = null;
            int maxIntensity = -1;
            foreach (var lamp in lamps)
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
            int minIntensity = -1 ;
            foreach (var lamp in lamps)
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
            foreach (var lamp in lamps)
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
            foreach (var lamp in lamps)
            {
                if (lamp.Status == DeviceStatus.On)
                {
                    result.Add(lamp);
                }
            }
            return result;
        }
        public List<LampDesign> FindAllOff()
        {
            List<LampDesign> result = new List<LampDesign>();
            foreach (var lamp in lamps)
            {
                if (lamp.Status == DeviceStatus.Off)
                {
                    result.Add(lamp);
                }
            }
            return result;
        } 
        public LampDesign? FindLampById(Guid id)
        {
            foreach (var lamp in lamps)
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
                return lamps.OrderByDescending(l => l.Intensity).ToList();
            }
            else
            {
                return lamps.OrderBy(l => l.Intensity).ToList();
            }
        }
    }
}
