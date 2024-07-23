using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class DonHangChiTiet
    {
        [Key]
        public int DonHangChiTietID { get; set; }

        [ForeignKey("SanPhamID")]
        public int SanPhamID { get; set; }
        public SanPham SanPham { get; set; }


        [ForeignKey("DonHangID")]
        public int DonHangID { get; set; }
        public DonHang DonHang { get; set; }


        public int SoLuong { get; set; }
    }
}
