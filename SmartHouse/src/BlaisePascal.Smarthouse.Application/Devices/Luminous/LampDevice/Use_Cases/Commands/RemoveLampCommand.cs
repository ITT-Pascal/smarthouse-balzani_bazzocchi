
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Commands;

public class RemoveLampCommand
{
    private readonly ILampRepository _lampRepository;
    public RemoveLampCommand(ILampRepository repo)
    {
        _lampRepository = repo;
    }
    public void Execute(Guid id)
    {
        _lampRepository.Remove(id);
    }
}
