using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous
{
    public class SetIntensityLampCommand
    {
        private readonly ILampRepository _repository;
        public SetIntensityLampCommand(ILampRepository repo)
        {
            _repository = repo;
        }
        public void Execute(Guid id, Intensity amount)
        {
            Lamp lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.SetIntensity(amount);
                _repository.Update(lamp);
            }
        }
    }
}
