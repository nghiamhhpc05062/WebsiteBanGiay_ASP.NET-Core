using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C4_Assignment.Models
{
    public class DanhMuc
    {
        [Key]
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
            
        public string HinhAnh { get; set; }
    }
}
