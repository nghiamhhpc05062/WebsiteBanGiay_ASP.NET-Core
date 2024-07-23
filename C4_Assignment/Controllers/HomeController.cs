using C4_Assignment.Data;
using C4_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;

namespace C4_Assignment.Controllers
{
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

        public IActionResult Information(int id)
        {
            var tt = _db.SanPhams.Where(x => x.SanPhamID == id);
            return View(tt);
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

        public IActionResult Login(TaiKhoan user)
        {
            var userid = user.TaiKhoanID;
            var username = user.TenDangNhap;
            var password = user.MatKhau;
            var usercheck = _db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap.Equals(username) && x.MatKhau.Equals(password));
            if (usercheck != null)
            {
                var checkname = _db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap.Equals(username));

                var phanquyen = _db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap.Equals(username) && x.PhanQuyen.Equals("Admin"));
                if (phanquyen != null)
                {
                    HttpContext.Session.SetString("NameUser", checkname.HoTen);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    HttpContext.Session.SetString("NameUser", checkname.HoTen);
                    return RedirectToAction("Index", "Home", new { area="User" });

                }
            }
            else
            {
                ViewData["kiemtra"] = "Đăng nhập thất bại";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
