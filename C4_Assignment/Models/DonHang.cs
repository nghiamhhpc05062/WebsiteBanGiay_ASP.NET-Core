using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class DonHang
    {
        [Key]
        public int DonHangID { get; set; }

        public string NgayDatHang { get; set; }
        public string TrangThai { get; set; }


        [ForeignKey("KhachHangID")]
        public int KhachHangID { get; set; }
        public KhachHang KhachHang { get; set; }


        [ForeignKey("NhanVienID")]
        public int NhanVienID { get; set; }
        public NhanVien NhanVien { get; set; }



    }
}
