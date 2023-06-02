using AppData.Models;

namespace AppView.IServices
{
    public interface ISanPhamCTServices
    {
        public bool CreateProduct(SanPhamCt s);
        public bool UpdateProduct(SanPhamCt s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<SanPhamCt> GetAllSanPhamCt();
        public SanPhamCt GetSanPhamCtById(Guid Id);
        public List<SanPhamCt> GetSanPhamCtByName(string Name);
    }
}
