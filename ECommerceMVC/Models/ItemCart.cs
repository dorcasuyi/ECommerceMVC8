namespace ECommerceMVC.Models
{
    public class ItemCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }  // Add the Product Name here
        public Product Product { get; set; }
    }
}
