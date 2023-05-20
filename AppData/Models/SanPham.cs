using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            SanPhamCts = new HashSet<SanPhamCt>();
        }

        public Guid Idsp { get; set; }
        public string? MaSp { get; set; }
        public string? TenSp { get; set; }

        public virtual ICollection<SanPhamCt> SanPhamCts { get; set; }
    }
}
