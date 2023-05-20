using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class HoaDonCt
    {
        public Guid Idhdct { get; set; }
        public Guid? Idhd { get; set; }
        public Guid? Idspct { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThai { get; set; }

        public virtual HoaDon? IdhdNavigation { get; set; }
        public virtual SanPhamCt? IdspctNavigation { get; set; }
    }
}
