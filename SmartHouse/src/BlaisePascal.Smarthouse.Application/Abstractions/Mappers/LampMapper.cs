using BlaisePascal.Smarthouse.Application.Devices.Luminous.Lamp.DTO;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Abstractions.Mappers
{
    public class LampMapper
    {
        public static LampDTO toDTO(Lamp lamp)
        {
            return new LampDTO
            {
                Id = lamp.Id,
                Name = lamp.Name.name,
                Status = lamp.Status.ToString(),
                CreatedAtUTC = lamp.CreatedAtUtc,
                LastModifiedAtUTC = lamp.LastModifiedAtUtc,
                Intensity = lamp.Intensity.Value
            };
        }
        public static Lamp toEntity(LampDTO lampDTO)
        {
            return new Lamp(
                new Name(lampDTO.Name)
                );
        }
    }
}
