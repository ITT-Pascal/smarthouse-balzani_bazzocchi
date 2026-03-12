using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.EcoLampDevice
{
    public class SwitchOffEcoLampCommand
    {
        private readonly IEcoLampRepository _repository;
        public SwitchOffEcoLampCommand(IEcoLampRepository repo)
        {
            _repository = repo;
        }
        public void Execute(Guid id, int amount)
        {
            EcoLamp ecolamp = _repository.GetById(id);
            if (ecolamp != null)
            {
                ecolamp.SwitchOff();
                _repository.Update(ecolamp);
            }
        }
    }
}
