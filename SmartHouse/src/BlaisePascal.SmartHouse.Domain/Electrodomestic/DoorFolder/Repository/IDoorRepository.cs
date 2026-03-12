using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Repository
{
    public interface IDoorRepository
    {
        void Add(Door door);
        void Update(Door door);
        void Remove(Guid id);
        void Close(Guid id);
        void Open(Guid id);
        void Lock(Guid id);
        void Unlock(Guid id);
        Door GetById(Guid id);
    }
}
