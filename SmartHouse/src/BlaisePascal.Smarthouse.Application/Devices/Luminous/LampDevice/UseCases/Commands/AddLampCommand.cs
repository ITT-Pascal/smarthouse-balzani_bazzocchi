using BlaisePascal.Smarthouse.Application.Abstractions.Mappers;
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.DTO;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Commands;
public class AddLampCommand
{
    private readonly ILampRepository _lampRepository;

    public AddLampCommand(ILampRepository repo)
    {
        _lampRepository = repo;
    }
    public void Execute(Name lampName)
    {
        Lamp lamp = new Lamp(lampName);
        _lampRepository.Add(lamp);
    }
}
