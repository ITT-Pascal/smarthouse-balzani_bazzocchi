using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV
{
    public class CCTV: AbstractDevice
    {
        public bool NightVision { get; set; }
        public RecordingStatus RecordingStatus { get; set; }
        public List<Recording> Recordings { get; private set; }
        TimeOnly StartOfDay;
        TimeOnly StartOfNight;
        public CCTV(string name, Guid id, List<Recording>recordings): base(name, id)
        {
            StartOfDay = new TimeOnly(21, 30);
            StartOfNight = new TimeOnly(7, 30);
            TimeOnly Now = new TimeOnly(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute);
            if (Now == StartOfDay)
                NightVision = false;
            if (Now == StartOfNight)
                NightVision = true;
            Recordings = recordings;
            RecordingStatus = RecordingStatus.NotRecording;
        }
        public void SwitchDayNightMode()
        {
            TimeOnly Now = new TimeOnly(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute);
            if(Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot switch day/night mode.");
            if (Status == DeviceStatus.On)
            {
                if (Now == StartOfDay)
                    NightVision = false;
                if (Now == StartOfNight)
                    NightVision = true;
            }
        }
        public void StartRecording()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot start recording.");
            if (Status == DeviceStatus.On)
            {
                RecordingStatus = RecordingStatus.Recording;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public void StopRecording(string nameOfRecording)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot stop recording.");
            if (Status == DeviceStatus.On && RecordingStatus == RecordingStatus.Recording)
            {
                RecordingStatus = RecordingStatus.NotRecording;
                Recordings.Add(new Recording(LastModifiedAtUtc, DateTime.UtcNow, nameOfRecording));
            }
        }
        public void DeleteRecording(string nameOfRecording)
        {
            foreach(var recording in Recordings)
            {
                if (recording.Name == nameOfRecording)
                {
                    Recordings.Remove(recording);
                }
                else
                {
                    throw new InvalidOperationException("Recording not found.");
                }
            }
        }
    }
}
