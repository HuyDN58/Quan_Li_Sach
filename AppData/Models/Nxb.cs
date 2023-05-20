using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Nxb
    {
        public Nxb()
        {
            SanPhamCts = new HashSet<SanPhamCt>();
        }

        public Guid Idnxb { get; set; }
        public string? Mansx { get; set; }
        public string? TenNxb { get; set; }

        public virtual ICollection<SanPhamCt> SanPhamCts { get; set; }
    }
}
