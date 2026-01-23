using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV
{
    public class CCTV: AbstractSecureDevice
    {
        public bool NightVision { get; private set; }
        public RecordingStatus RecordingStatus { get; private set; }
        public List<Recording> Recordings { get; private set; }
        public TimeOnly StartOfDay { get; private set; }
        public TimeOnly StartOfNight { get; private set; }
        public DateTime _recordingStartTime;

        public CCTV(string name, Guid id, int securityCode): base(name, id, securityCode)
        {
            StartOfDay = new TimeOnly(7, 30);
            StartOfNight = new TimeOnly(21, 30);
            TimeOnly Now = new TimeOnly(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute);
            if (Now == StartOfDay)
                NightVision = false;
            if (Now == StartOfNight)
                NightVision = true;
            Recordings = new List<Recording>();
            RecordingStatus = RecordingStatus.NotRecording;            
        }

        
        public void SwitchDayNightMode()
        {
            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot switch day/night mode.");
            bool isNightTime = now >= StartOfNight || now < StartOfDay;
            if (isNightTime)
            {
                NightVision = true;
            }
            else
            {
                NightVision = false;
            }
        }
        public void StartRecording()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot start recording.");
            if (Status == DeviceStatus.On)
            {
                RecordingStatus = RecordingStatus.Recording;
                _recordingStartTime = DateTime.UtcNow;
            }
        }
        public bool StopRecording(string recordingName)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("CCTV is off. Cannot stop recording.");
            if (Status == DeviceStatus.On && RecordingStatus == RecordingStatus.Recording)
            {
                for (int i = 0; i < Recordings.Count(); i++)
                {
                    if (Recordings[i].Name == recordingName)
                        return false;
                }
                RecordingStatus = RecordingStatus.NotRecording;
                Recordings.Add(new Recording(_recordingStartTime, DateTime.UtcNow, recordingName));
                return true;
            }
                return false;
        }

        public bool RenameRecording(string nameToChange, string newName)
        {
            if (nameToChange == null || newName == null)
                throw new ArgumentNullException("Non sono stati inseriti i nomi delle registrazioni richiesti.");
            foreach(var recording in Recordings)
            {
                if (recording.Name == nameToChange)
                {
                    recording.Name = newName;
                    return true;                   
                }
            }
            return false;
        }

        public void DeleteRecording(string nameOfRecording)
        {
            Recording? recordingToDelete = null;
            foreach (var recording in Recordings)
            {
                if (recording.Name == nameOfRecording)
                {
                    recordingToDelete = recording; 
                    break;
                }
            }
            if (recordingToDelete != null)
            {
                Recordings.Remove(recordingToDelete);
            }
            else
            {
                throw new InvalidOperationException("Recording not found.");
            }
        }

        public bool SearchRecordingByName(string name)
        {
            for (int i = 0; i < Recordings.Count(); i++)
            {
                if (Recordings[i].Name == name)
                    return true;
            }
            return false;
        }

        public List<Recording> SearchRecordingByDate(DateOnly date)
        {
            List<Recording> recordingsInDate = new List<Recording>();
            for (int i = 0; i < Recordings.Count(); i++)
            {
                if (DateOnly.FromDateTime(Recordings[i].Date) == date)
                {
                    recordingsInDate.Add(Recordings[i]);
                }
            }
            return recordingsInDate;
        }
    }
}
