using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice.Use_Cases.Queries
{
    public class GetDoorByIdQuerie
    {
        private readonly IDoorRepository _doorRepository;
        public GetDoorByIdQuerie(IDoorRepository repo)
        {
            _doorRepository = repo;
        }

        public Door Execute(Name name, PIN pin, Guid id)
        {
            var l = _doorRepository.GetById(id);
            return l;
        }
    }
}
