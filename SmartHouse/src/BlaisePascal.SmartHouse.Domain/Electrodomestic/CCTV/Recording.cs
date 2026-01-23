using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV
{
    public class Recording
    {
        public TimeSpan Duration { get; private set; }
        public string Name { get; set; }
        public DateTime Date { get; private set; }
        public Recording(DateTime startRecordingTime, DateTime endRecordingTime, string name)
        {
            Duration = endRecordingTime - startRecordingTime;
            Name = name;
            Date = endRecordingTime;
        }
    }
}
