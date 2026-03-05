using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.DTO
{
    public class LampDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Status { get; init; }
        public DateTime CreatedAtUTC { get; init; }
        public DateTime LastModifiedAtUTC { get; init; }
        public int Intensity { get; init; }
    }
}
