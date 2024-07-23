using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class KhachHang
    {
        [Key]
        public int KhachHangID { get; set; }
        public string HoTen { get; set; }
        public double SoDienThoai { get; set; }
        public string MaBuuDien  { get; set; }
        public string DiaChi { get; set; }
    }
}
