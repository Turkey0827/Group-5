using System.Collections.Generic;
using System.Linq;

namespace Group5_Website.Models
{
    public class Cartitem
    {
        public int CartItemId { get; set; }
        public Clothes Product { get; set; }  // 引用 Clothes 对象
        public int Quantity { get; set; }      // 商品数量

        // 计算当前商品的总价
        public decimal GetTotalPrice()
        {
            return Product.item_Price * Quantity; // 计算当前商品的总价
        }
    }

    public class Cart
    {
        private List<Cartitem> Items { get; set; } = new List<Cartitem>();

        // 添加商品到购物车
        public void AddItem(Clothes product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.item_Name == product.item_Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;  // 商品已存在，增加数量
            }
            else
            {
                Items.Add(new Cartitem { Product = product, Quantity = quantity }); // 添加新商品
            }
        }

        // 移除商品
        public void RemoveItem(string itemName)
        {
            Items.RemoveAll(i => i.Product.item_Name == itemName); // 使用字符串类型的商品名称
        }

        // 更新商品数量
        public void UpdateQuantity(string itemName, int newQuantity)
        {
            var item = Items.FirstOrDefault(i => i.Product.item_Name == itemName);
            if (item != null)
            {
                item.Quantity = newQuantity;  // 更新数量
            }
        }

        // 计算购物车的总金额
        public decimal GetTotalAmount()
        {
            return Items.Sum(i => i.GetTotalPrice()); // 计算购物车的总价
        }

        // 获取所有购物车项
        public List<Cartitem> GetItems()
        {
            return Items;
        }
    }
}
