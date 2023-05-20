using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public Guid Idnv { get; set; }
        public string? MaNv { get; set; }
        public string? TenNv { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public Guid? IdnguoiDung { get; set; }
        public int? TrangThai { get; set; }

        public virtual Account? IdnguoiDungNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
