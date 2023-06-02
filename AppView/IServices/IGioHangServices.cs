using AppData.Models;

namespace AppView.IServices
{
    public interface IGioHangServices
    {
        public bool CreateProduct(GioHang s);
        public bool UpdateProduct(GioHang s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<GioHang> GetAllGioHang();
        public GioHang GetGioHangById(Guid Id);
        public List<GioHang> GetGioHangByName(string Name);
    }
}
