using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV
{
    public class Recording
    {
        public DateTime StartRecordingTime { get; private set; }
        public DateTime EndRecordingTime { get; private set; }
        public string Name { get; private set; }
        public Recording(DateTime startRecordingTime, DateTime endRecordingTime, string name)
        {
            StartRecordingTime = startRecordingTime;
            EndRecordingTime = endRecordingTime;
            Name = name;
        }
    }
}
