using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers.Users
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
