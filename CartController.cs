using Microsoft.AspNetCore.Mvc;
using Group5_Website.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly Group5_Website.Data.AppDbContext _db;

        public CartController(Group5_Website.Data.AppDbContext db)
        {
            _db = db;
        }

        // 显示购物车
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // 添加商品
        public IActionResult AddItem(int itemId, int quantity)
        {
            var product = _db.Clothes.Find(itemId);
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.Product.item_Id == itemId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem { Product = product, Quantity = quantity, CartId = cart.CartId });
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            var cart = _db.Carts // 使用 DbSet<Cart>
          .Include(c => c.Items) // 加载购物车项
          .ThenInclude(i => i.Product) // 加载产品
          .FirstOrDefault(c => c.UserId == GetUserId());


            if (cart == null)
            {
                cart = new Cart { UserId = GetUserId() }; // 创建新购物车
                _db.Carts.Add(cart); // 添加到数据库
                _db.SaveChanges(); // 保存更改
            }

            return cart;
        }


        private int GetUserId()
        {
            // 这里根据实际情况获取用户ID
            return 1; // 示例：硬编码用户ID
        }
    }
}
