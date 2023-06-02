using AppData.Models;

namespace AppView.IServices
{
    public interface ISanPhamServices
    {
        public bool CreateProduct(SanPham s);
        public bool UpdateProduct(SanPham s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<SanPham> GetAllSanPham();
        public SanPham GetSanPhamById(Guid Id);
        public List<SanPham> GetSanPhamByName(string Name);
    }
}

