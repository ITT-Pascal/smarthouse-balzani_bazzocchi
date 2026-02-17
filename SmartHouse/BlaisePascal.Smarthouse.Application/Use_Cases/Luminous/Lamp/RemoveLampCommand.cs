using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous_Use_Cases
{
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
}
