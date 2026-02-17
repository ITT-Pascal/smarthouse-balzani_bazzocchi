using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using ImageProcessor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories
{
    public interface IEcoLampRepository
        {
            void Add(EcoLamp lamp);
            void Update(EcoLamp lamp);
            void Remove(Guid id);
            EcoLamp GetById(Guid id);
            List<EcoLamp> GetAll();
            List<EcoLamp> GetLampsNearAutoOff();
        }
}
