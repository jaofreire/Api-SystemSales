using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SalesSystem.Model
{
    public class RequestsFinaledsModel
    {
        public int Id {  get; set; }
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        
        private double _totalValue;

        public double TotalValue
        {
            get
            {
                return _totalValue = ProductPrice * ProductQuantity;
            }
            private set
            {
                value = ProductPrice * ProductQuantity;
                _totalValue = value;
            }
        }

    }
}
