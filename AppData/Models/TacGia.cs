using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class TacGia
    {
        public TacGia()
        {
            SanPhamCts = new HashSet<SanPhamCt>();
        }

        public Guid Idtg { get; set; }
        public string? Matg { get; set; }
        public string? TenTg { get; set; }

        public virtual ICollection<SanPhamCt> SanPhamCts { get; set; }
    }
}
