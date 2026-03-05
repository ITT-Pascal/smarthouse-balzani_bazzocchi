using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.EcoLampDevice
{
    public class AddEcoLampCommand
    {
        private readonly IEcoLampRepository _ecoLampRepository;
        public AddEcoLampCommand(IEcoLampRepository repo)
        {
            _ecoLampRepository = repo;
        }
        public void Execute(Name name)
        {
            _ecoLampRepository.Add(new EcoLamp(name));
        }
    }
}


