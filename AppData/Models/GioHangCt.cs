using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class GioHangCt
    {
        public Guid Idghct { get; set; }
        public Guid? Idspct { get; set; }
        public Guid? Idgh { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThai { get; set; }

        public virtual GioHang? IdghNavigation { get; set; }
        public virtual SanPhamCt? IdspctNavigation { get; set; }
    }
}
