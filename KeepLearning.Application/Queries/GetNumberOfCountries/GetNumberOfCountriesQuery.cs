﻿using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Domain.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQuery: IRequest<int>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
