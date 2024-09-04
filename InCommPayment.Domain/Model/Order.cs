namespace InCommPayment.Domain.Model
{
    public class Order
    {
        public string Id { get; set; }
        public List<Product> ListProducts { get; set; }
        public float TotalPrice { get; set; }
    }
}
