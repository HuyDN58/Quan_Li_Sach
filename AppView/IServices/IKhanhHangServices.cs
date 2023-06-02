using AppData.Models;

namespace AppView.IServices
{
    public interface IKhanhHangServices
    {
        public bool CreateProduct(KhachHang s);
        public bool UpdateProduct(KhachHang s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<KhachHang> GetAllKhachHang();
        public KhachHang GetKhachHangById(Guid Id);
        public List<KhachHang> GetKhachHangByName(string Name);
    }
}
