using AppData.Models;
using AppView.IServices;
using System.Drawing;

namespace AppView.Services
{
    public class SanPhamServices:ISanPhamServices
    {
        QUAN_LI_SACH_NET105Context context;
        public SanPhamServices()
        {
            context = new QUAN_LI_SACH_NET105Context();
        }
        public bool CreateProduct(SanPham s)
        {
            try
            {
                context.SanPhams.Add(s);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(Guid Id)
        {
            try
            {
                var sanPham = context.SanPhams.Find(Id);
                context.SanPhams.Remove(sanPham);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SanPham> GetAllSanPham()
        {
            return context.SanPhams.ToList();
        }

        public SanPham GetSanPhamById(Guid Id)
        {
            return context.SanPhams.FirstOrDefault(p => p.Idsp == Id);
        }

        public List<SanPham> GetSanPhamByName(string Name)
        {
            return context.SanPhams.Where(p => p.TenSp.Contains(Name)).ToList();
        }

        public bool UpdateProduct(SanPham s)
        {
            try
            {
                var sanPham = context.SanPhams.Find(s.Idsp);
                sanPham.MaSp = s.MaSp;
                sanPham.TenSp = s.TenSp;

                context.SanPhams.Update(sanPham);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
