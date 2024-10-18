namespace Group5_Website.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public Clothes Product { get; set; }
        public int Quantity { get; set; }
    }
}
