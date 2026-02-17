using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous_Use_Cases
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;
        public AddLampCommand(ILampRepository repo)
        {
            _lampRepository = repo;
        }

        public void Execute(Name lampName)
        {

            _lampRepository.Add(new Lamp(lampName));

        }
    }
}
