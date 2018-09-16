namespace GraphQLDotNet.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Barcode { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
