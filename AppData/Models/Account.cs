using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Account
    {
        public Account()
        {
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }

        public Guid IdnguoiDung { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
