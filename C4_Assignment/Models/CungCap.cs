using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace C4_Assignment.Models
{
    public class CungCap
    {
        [Key]
        public int CungCapID { get; set; }
        public string TenCungCap { get; set; }
        public string ThanhPho { get; set; }
        public string QuocGia { get; set; }

    }
}
