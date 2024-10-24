using CarBookApp.Application.Features.CQRS.Results.CarResults;
using CarBookApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetLast5CarsWithBrandsAsync();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                Transmission = x.Transmission,
                CoverImgUrl = x.CoverImgUrl,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat
            }).ToList();
        }
    }
}
