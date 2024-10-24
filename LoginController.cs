namespace Group5_Website.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace Group5_Website.Controllers
    {
        public class LoginController : Controller
        {
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
}
