using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice.Use_Cases.Commands
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
