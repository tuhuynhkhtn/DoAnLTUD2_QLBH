using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1.Model
{
    public class ProInfo
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string TinyDes { get; set; }
        public string FullDes { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SoLuotXem { get; set; }
        public int SoLuongBan { get; set; }
        public string XuatXu { get; set; }
        public string Loai { get; set; }
        public string NhaSanXuat { get; set; }
    }
}
