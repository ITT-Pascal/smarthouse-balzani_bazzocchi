using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.Lamp.DTO
{
    public class LampDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAtUTC { get; set; }
        public DateTime LastModifiedAtUTC { get; set; }
        public int Intensity { get; set; }
    }
}
