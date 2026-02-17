using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Repository;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public AddDoorCommand(IDoorRepository repo)
        {
            _doorRepository = repo;
        }

        public void Execute(Name name, PIN pin)
        {
            _doorRepository.Add(new Door(pin, name));
        }
    }
}
