using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Commands
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
                lamp.SwitchOn();
                _repository.Update(lamp);
            }
        }
    }
}
