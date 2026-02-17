using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases
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
