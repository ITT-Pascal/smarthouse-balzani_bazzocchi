using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases
{
    public class GetDoorByIdCommand
    {
        private readonly IDoorRepository _doorRepository;
        public GetDoorByIdCommand(IDoorRepository repo)
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
