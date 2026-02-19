using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous
{
    public class SwitchOnLampCommand
    {
        private readonly ILampRepository _repository;
        public SwitchOnLampCommand(ILampRepository repo)
        {
            _repository = repo;
        }
        public void Execute(Guid id)
        {
            Lamp lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.SwitchOff();
                _repository.Update(lamp);
            }
        }
    }
}
