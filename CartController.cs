using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Extension; // 确保引用了扩展类所在的命名空间


namespace WebApplication1.Controllers
{
    public class CartController:Controller
    {
        private CartController _cart;
        public IActionResult Index()
        {
            var cart = _cart.GetCart(); 
           
            return View(cart);
        }

        private string? GetCart()
        {
            throw new NotImplementedException();
        }

        //添加商品到购物车
        public IActionResult AddItem(int item_Id, string item_Name, decimal item_Price, int item_Quantity = 1)
        {
            
            _cart.AddItem(item_Id,item_Name,item_Quantity);
            return RedirectToAction("Index");
        }
        //从购物车删除商品
        public IActionResult RemoveItem(int item_Id)
        {
            _cart.RemoveItem(item_Id);
            return RedirectToAction("Index");
        }
        //更新商品数量
        public IActionResult UpdateQuantity(int item_Id, int item_Quantity)
        {
            if (item_Quantity > 0)
            {
                _cart.UpdateQuantity(item_Id, item_Quantity);
            }
            else
            {
                _cart.RemoveItem(item_Id);
            }
            return RedirectToAction("Index");
        }


        //会话，保存用户购物车数据
        public ActionResult AddToCart(int item_Id,int item_Quantity=1)
        {
            var cart = GetCart();//获取购物车
            //添加商品
            SaveCartToSession(cart);
            return RedirectToAction("Index");
        }

        private void SaveCartToSession(string? cart)
        {
            throw new NotImplementedException();
        }
    }
}
