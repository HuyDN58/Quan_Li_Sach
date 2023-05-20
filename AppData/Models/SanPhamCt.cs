using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class SanPhamCt
    {
        public SanPhamCt()
        {
            GioHangCts = new HashSet<GioHangCt>();
            HoaDonCts = new HashSet<HoaDonCt>();
        }

        public Guid Idspct { get; set; }
        public Guid? Idsp { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuongTon { get; set; }
        public Guid? Idtg { get; set; }
        public Guid? Idnxb { get; set; }
        public string? MoTa { get; set; }
        public int? TrangThai { get; set; }

        public virtual Nxb? IdnxbNavigation { get; set; }
        public virtual SanPham? IdspNavigation { get; set; }
        public virtual TacGium? IdtgNavigation { get; set; }
        public virtual ICollection<GioHangCt> GioHangCts { get; set; }
        public virtual ICollection<HoaDonCt> HoaDonCts { get; set; }
    }
}
