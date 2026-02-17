using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous_Use_Cases
{
    public class RemoveEcoLampCommand
    {
        private readonly IEcoLampRepository _ecoLampRepository;
        public RemoveEcoLampCommand(IEcoLampRepository repo)
        {
            _ecoLampRepository = repo;
        }

        public void Execute(Guid id)
        {
            _ecoLampRepository.Remove(id);
        }
    }
}
