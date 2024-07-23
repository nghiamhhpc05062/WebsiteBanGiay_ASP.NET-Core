using C4_Assignment.Data;
using C4_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace C4_Assignment.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDBContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDBContext dBContext)
        {
            _logger = logger;
            _db = dBContext;
        }
        public IActionResult Index()
        {
            var dm = _db.DanhMucss.ToList();
            ListProduct list = new ListProduct();
            list.danhMucz = _db.DanhMucss.ToList();
            list.sanPhamz = _db.SanPhams.ToList();
            return View(list);
        }

        public IActionResult Product(int id)
        {
            var sp = _db.SanPhams.Where(x => x.DanhMucID == id);
            return View(sp);
        }

        public IActionResult Information(int? id)
        {
            var infor = _db.SanPhams.Where(x => x.SanPhamID == id);
            return View(infor);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Cart(int? id)
        {
            var z = _db.SanPhams.Where(x => x.SanPhamID == id);
            return View(z);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
