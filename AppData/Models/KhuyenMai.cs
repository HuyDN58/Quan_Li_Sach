using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public Guid Idkm { get; set; }
        public string? MaKm { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }
        public int? PhanTramGiam { get; set; }
        public int? TrangThai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
