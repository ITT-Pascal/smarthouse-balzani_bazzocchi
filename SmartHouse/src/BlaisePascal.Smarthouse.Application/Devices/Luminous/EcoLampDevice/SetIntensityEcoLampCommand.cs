using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.EcoLampDevice
{
    public class SetIntensityEcoLampCommand
    {
        private readonly IEcoLampRepository _repository;
        public SetIntensityEcoLampCommand(IEcoLampRepository repo)
        {
            _repository = repo;
        }
        public void Execute(Guid id, Intensity amount)
        {
            EcoLamp ecolamp = _repository.GetById(id);
            if (ecolamp != null)
            {
                ecolamp.SetIntensity(amount);
                _repository.Update(ecolamp);
            }
        }
    }
}
