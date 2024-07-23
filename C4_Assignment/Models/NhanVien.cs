using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class NhanVien
    {
        [Key]
        public int NhanVienID { get; set; }
        public string Username { get; set; }
        public string Anh { get; set; }
        public string HoTen { get; set; }
        public string NgayVaoLam { get; set; }
        public string ChucVu { get; set; }
    }
}
