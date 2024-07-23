using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C4_Assignment.Models
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }
        public int soluong { get; set; }

        [ForeignKey("TaiKhoanID")]
        public int TaiKhoanID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }

        [ForeignKey("SanPhamID")]
        public int SanPhamID { get; set; }
        public SanPham sanPham { get; set; }
    }
}
