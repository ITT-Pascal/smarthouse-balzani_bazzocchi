using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice;

public class ChangeDoorCodeCommand
{
    private readonly IDoorRepository _doorRepository;
    public ChangeDoorCodeCommand(IDoorRepository repo)
    {
        _doorRepository = repo;
    }
    public void Execute(Guid id,int oldCode, int newCode)
    {
        Door door = _doorRepository.GetById(id);
        if (door._lock)
            door.Open();
        _doorRepository.Update(door);
    }
}
