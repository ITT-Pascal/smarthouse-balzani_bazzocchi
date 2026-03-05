using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.Lamp.Use_Cases.Commands
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
