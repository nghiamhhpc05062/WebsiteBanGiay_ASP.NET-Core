
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class SanPham
    {
        [Key]
        public int SanPhamID { get; set; }

        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
        public double Gia { get; set; }
        public string MauSac { get; set; }
        public string KichThuoc { get; set; }

        [ForeignKey("DanhMucID")]
        public int DanhMucID { get; set; }
        public DanhMuc DanhMuc { get; set; }
        

        [ForeignKey("CungCapID")]
        public int CungCapID { get; set; }
        public CungCap CungCap { get; set; }
    }
}