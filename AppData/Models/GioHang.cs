using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class GioHang
    {
        public GioHang()
        {
            GioHangCts = new HashSet<GioHangCt>();
        }

        public Guid Idgh { get; set; }
        public Guid? Idkh { get; set; }

        public virtual KhachHang? IdkhNavigation { get; set; }
        public virtual ICollection<GioHangCt> GioHangCts { get; set; }
    }
}
