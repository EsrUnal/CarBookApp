
namespace CarBookApp.Application.Mediator.Results.CarPricingResults
{
    public class GetCarPricingQueryResult
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
