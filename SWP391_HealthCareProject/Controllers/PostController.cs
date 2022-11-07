using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index(int id)
        {
            var postDao = new PostDAO();
            var pD = postDao.getPostById(id);
            return View(pD);
        }
       
       
    }
}