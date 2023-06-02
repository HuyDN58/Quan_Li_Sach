using AppData.Models;

namespace AppView.IServices
{
    public interface IHoaDonServices
    {
        public bool CreateProduct(HoaDon s);
        public bool UpdateProduct(HoaDon s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<HoaDon> GetAllHoaDon();
        public HoaDon GetGioHoaDonById(Guid Id);
        public List<HoaDon> GetHoaDonByName(string Name);
    }
}
