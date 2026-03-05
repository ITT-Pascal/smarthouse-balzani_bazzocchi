using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Infrastructure.Repositories.LampRepository
{
    public class InMemoryLampRepository : ILampRepository
    {
        public InMemoryLampRepository() { }

        public Lamp getById(Guid id)
        {

        }
    }
}
