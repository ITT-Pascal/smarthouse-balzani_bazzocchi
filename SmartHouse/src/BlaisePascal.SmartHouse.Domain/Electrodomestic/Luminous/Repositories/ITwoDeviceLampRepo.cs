using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories
{
    public interface ITwoDeviceLampRepository
    {
        void Add(TwoDeviceLamp lamp);
        void Update(TwoDeviceLamp lamp);
        void Remove(Guid id);
        TwoDeviceLamp GetById(Guid id);
    }
}
