using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;

namespace BlaisePascal.Smarthouse.Application.Use_Cases.Luminous_Use_Cases;

public class GetEcoLampByIdQuery
{
    private readonly IEcoLampRepository _lampRepository;
    public GetEcoLampByIdQuery(IEcoLampRepository repository)
    {
        _lampRepository = repository;
    }
    public EcoLamp Execute(Guid id)
    {
        var l = _lampRepository.GetById(id);
        return l;
    }
}
