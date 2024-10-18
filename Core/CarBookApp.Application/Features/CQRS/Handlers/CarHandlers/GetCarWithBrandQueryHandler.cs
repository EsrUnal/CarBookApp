using CarBookApp.Application.Features.CQRS.Results.CarResults;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrandsAsync();
            return values.Select(value => new GetCarWithBrandQueryResult
            {
                BrandName = value.Brand.Name,
                CarID = value.CarID,
                BrandID = value.BrandID,
                Transmission = value.Transmission,
                CoverImgUrl = value.CoverImgUrl,
                Fuel = value.Fuel,
                BigImageUrl = value.BigImageUrl,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat
            }).ToList();
        }
    }
}
