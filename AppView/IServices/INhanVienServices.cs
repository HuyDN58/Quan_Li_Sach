using AppData.Models;

namespace AppView.IServices
{
    public interface INhanVienServices
    {
        public bool CreateProduct(NhanVien s);
        public bool UpdateProduct(NhanVien s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<NhanVien> GetAllNhanVien();
        public NhanVien GetNhanVienById(Guid Id);
        public List<NhanVien> GetNhanVienByName(string Name);
    }
}
