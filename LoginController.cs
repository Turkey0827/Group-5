using Group5_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Group5_Website.Models;
using BCrypt.Net;

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
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password,user.Password))
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
        
            public IActionResult Register()
            {
                return View(); // 
            }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                //检查命名是否重复
                if (_db.Users.Any(u => u.Name == model.Name))
                {
                    ModelState.AddModelError("", "The user name already exists");
                    return View(model);
                }
                //创建新用户，并保存新用户到数据库中
                var user = new User
                {
                    Name = model.Name,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                _db.Users.Add(user);
                _db.SaveChanges();

                //注册成功，重定向到登录页面
                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Manager(string Account, string Password)
        {
            var user = AuthenticateUser(Account,Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "User name or password is wrong");
            return View();
        }
        }
    }

