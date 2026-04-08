using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Mappers;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;
        public GetLampByIdQuery(ILampRepository repository)
        {
            _lampRepository = repository;
        }
        public LampDTO? Execute(Guid id)
        {
            var l = _lampRepository.GetById(id);
            if(l != null )
                return LampMapper.toDTO(l);
            return null;
        }
    }
}
