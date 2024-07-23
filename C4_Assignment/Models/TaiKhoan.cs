using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class TaiKhoan
    {
        [Key]
        public int TaiKhoanID { get; set; }

        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        public string HoTen { get; set; }

        public string GioiTinh { get; set; }

        public string? PhanQuyen { get; set; }
            
    }
}
