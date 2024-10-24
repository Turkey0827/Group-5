using Group5_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Group5_Website.Models;
using System.Linq;

    namespace Group5_Website.Controllers
    {
        public class LoginController : Controller
        {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {//登录成功，保存会话
                    HttpContext.Session.SetString("User", user.Name);
                    return RedirectToAction("Index", "Home");
                    

                }
                else
                {
                    ModelState.AddModelError("", "User Name or Password is Wrong");
                }
            }
            return View(model);
        }

        public IActionResult Login()
            {
                return View(); // 这会自动查找 /Views/Login/Index.cshtml
            }
            public IActionResult Register()
            {
                return View(); // 
            }
        }
    }

