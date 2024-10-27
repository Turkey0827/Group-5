using Microsoft.AspNetCore.Mvc;
using Group5_Website.Models;
using Group5_Website.Data;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Group5_Website.Controllers
{
    public class ClothesController : Controller
    {
        private readonly AppDbContext _db;
        public ClothesController(AppDbContext db)
        {
            _db = db;
        }
        //女装列表
        public IActionResult Female()
        {
            var femaleClothes = _db.Clothes.Where(c => c.item_Type == "Female").ToList();
            return View(femaleClothes);
        }
        //男装列表
        public IActionResult Male()
        {
            var maleClothes = _db.Clothes.Where(c => c.item_Type == "Male").ToList();
            return View(maleClothes);
        }
        //单个商品详情
        public IActionResult Details(int id)
        {
            var item = _db.Clothes.FirstOrDefault(c => c.item_Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        
    }
}
