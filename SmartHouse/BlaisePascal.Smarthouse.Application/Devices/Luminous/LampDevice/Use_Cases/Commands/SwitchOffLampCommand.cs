using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.Lamp.Use_Cases.Commands
{
    public class SwitchOffLampCommand
    {
        private readonly ILampRepository _repository;
        public SwitchOffLampCommand(ILampRepository repo)
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
