using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice.Use_Cases.Commands
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public OpenDoorCommand(IDoorRepository repo)
        {
            _doorRepository = repo;
        }

        public void Execute(Guid id)
        {
            Door door = _doorRepository.GetById(id);
            if (door.Status == DeviceStatus.Close)
                door.Open();
            _doorRepository.Update(door);
        }
    }
}
