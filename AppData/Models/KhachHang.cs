using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        public Guid Idkh { get; set; }
        public string? Ma { get; set; }
        public string? TenKh { get; set; }
        public Guid? IdnguoiDung { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public int? TrangThai { get; set; }

        public virtual Account? IdnguoiDungNavigation { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
