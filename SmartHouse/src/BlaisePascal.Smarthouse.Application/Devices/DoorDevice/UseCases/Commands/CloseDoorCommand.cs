using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice.Use_Cases.Commands
{
    public class CloseDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public CloseDoorCommand(IDoorRepository repo)
        {
            _doorRepository = repo;
        }

        public void Execute(Guid id)
        {
            Door door = _doorRepository.GetById(id);
            door.Close();
            _doorRepository.Update(door);
        }
    }
}
