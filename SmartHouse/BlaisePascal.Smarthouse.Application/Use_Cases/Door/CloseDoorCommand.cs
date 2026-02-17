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
            if (door.Status == DeviceStatus.Open)
                door.Close();
            _doorRepository.Update(door);
        }
    }
}
