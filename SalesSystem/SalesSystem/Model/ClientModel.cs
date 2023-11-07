namespace SalesSystem.Model
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQuantity { get; set; }


        public ProductModel? Product { get; set; }

    }
}
