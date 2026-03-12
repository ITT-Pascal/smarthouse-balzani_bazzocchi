using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.EcoLampDevice
{
    public class SwitchOnEcoLampCommand
    {
        private readonly IEcoLampRepository _repository;
        public SwitchOnEcoLampCommand(IEcoLampRepository repo) 
        {
            _repository = repo;
        }
        public void Execute(Guid id)
        {

            EcoLamp ecolamp = _repository.GetById(id);
            if (ecolamp != null)
            {
                ecolamp.SwitchOn();
                _repository.Update(ecolamp);
            }
        }
    }
}
