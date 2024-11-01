using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Dto.CarPricingDtos
{
    public class ResultCarPricingsWithCarsDtos
    {
        public int CarPricingID { get; set; } 
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string PricingName { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
        public string CoverImgUrl { get; set; } 
    }
}
