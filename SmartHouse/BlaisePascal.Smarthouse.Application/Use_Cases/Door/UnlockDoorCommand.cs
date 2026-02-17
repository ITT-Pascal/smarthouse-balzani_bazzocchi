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
    public class UnlockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public UnlockDoorCommand(IDoorRepository repo)
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
