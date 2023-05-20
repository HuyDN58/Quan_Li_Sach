using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonCts = new HashSet<HoaDonCt>();
        }

        public Guid Idhd { get; set; }
        public string? MaHd { get; set; }
        public Guid? Idkh { get; set; }
        public Guid? Idnv { get; set; }
        public Guid? Idkm { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? TrangThai { get; set; }

        public virtual KhachHang? IdkhNavigation { get; set; }
        public virtual KhuyenMai? IdkmNavigation { get; set; }
        public virtual NhanVien? IdnvNavigation { get; set; }
        public virtual ICollection<HoaDonCt> HoaDonCts { get; set; }
    }
}
