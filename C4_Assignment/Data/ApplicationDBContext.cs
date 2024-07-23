using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace C4_Assignment.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Models.TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Models.CungCap> CungCaps { get; set; }
        public DbSet<Models.DanhMuc> DanhMucss { get; set; }
        public DbSet<Models.SanPham> SanPhams { get; set; }
        public DbSet<Models.KhachHang> KhachHangs { get; set; }
        public DbSet<Models.NhanVien> NhanViens { get; set; }
        public DbSet<Models.DonHang> DonHangs { get; set; }
        public DbSet<Models.DonHangChiTiet> DonHangChiTiets { get; set; }

        public DbSet<Models.GioHang> GioHangs { get; set; }
    }
}
