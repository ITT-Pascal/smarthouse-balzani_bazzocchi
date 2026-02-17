using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous_Use_Cases
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


