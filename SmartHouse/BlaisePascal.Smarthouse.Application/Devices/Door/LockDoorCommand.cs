using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Entities;

namespace BlaisePascal.Smarthouse.Application.Use_Cases
{
    public class LockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public LockDoorCommand(IDoorRepository repo)
        {
            _doorRepository = repo;
        }

        public void Execute(Guid id, PIN pin)
        {
            Door door = _doorRepository.GetById(id);
            if (door.Status == DeviceStatus.Lock)
                door.Unlock(pin);
            _doorRepository.Update(door);
        }
    }
}
