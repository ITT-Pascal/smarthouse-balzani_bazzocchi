
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.DTO;
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Mappers;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Queries
{
    //public class GetAllLampQuery
    //{
    //    private readonly ILampRepository _lampRepository;
    //    public GetAllLampQuery(ILampRepository repository)
    //    {
    //        _lampRepository = repository;
    //    }
    //    public List<LampDTO> Execute()
    //    {
    //        List<LampDTO> result = new List<LampDTO>();
    //        foreach (Lamp l in _lampRepository.GetAll())
    //        {
    //            result.Add(LampMapper.toDTO(l));
    //        }

    //        return result;
    //    }
    //}
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetAllLampsQuery(ILampRepository repository)
        {
            _lampRepository = repository;
        }

        public List<LampDTO>? Execute()
        {
            var result = new List<LampDTO>();
            foreach (var l in _lampRepository.GetAll())
                result.Add(LampMapper.toDTO(l));
            return result;
        }
    }
}
