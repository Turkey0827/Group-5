namespace Group5_Website.Models
{
  
        public class Cart
        {
            public int CartId { get; set; } // 购物车ID
            public int UserId { get; set; } // 用户ID
            public List<CartItem> Items { get; set; } = new List<CartItem>(); // 商品项
        }
    }