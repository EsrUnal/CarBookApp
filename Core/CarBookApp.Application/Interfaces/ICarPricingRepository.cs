﻿using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Interfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCarsAsync();
    }
}
