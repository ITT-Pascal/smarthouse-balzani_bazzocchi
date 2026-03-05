using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.DoorDevice.Use_Cases.Commands;

public class ChangeDoorCodeCommand
{
    private readonly IDoorRepository _doorRepository;
    public ChangeDoorCodeCommand(IDoorRepository repo)
    {
        _doorRepository = repo;
    }
    public void Execute(Guid id,PIN oldCode, PIN newCode)
    {
        Door door = _doorRepository.GetById(id);
        door.SetNewUnlockCode(oldCode, newCode);
        _doorRepository.Update(door);
    }
}
