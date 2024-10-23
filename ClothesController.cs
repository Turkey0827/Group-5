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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Page(ClothesController model, IFormFile item_Image)
        {
            if (item_Image != null && item_Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    item_Image.CopyTo(memoryStream);
                    //将图片转化为byte[],并且存入数据库
                    model.item_Imageurl = memoryStream.ToArray();
                }
            }
            _db.Clothes.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Page()
        {
            return View();
        }
    }
}
