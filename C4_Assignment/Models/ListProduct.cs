using System.Collections.Generic;

namespace C4_Assignment.Models
{
    public class ListProduct
    {
        public List<DanhMuc> danhMucz { get; set; }
        public List<SanPham> sanPhamz { get; set; }
        public static ListProduct list = new ListProduct();

        public ListProduct()
        {
            danhMucz = new List<DanhMuc>();
            sanPhamz = new List<SanPham>();
        }
    }
}
