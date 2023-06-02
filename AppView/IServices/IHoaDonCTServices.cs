using AppData.Models;

namespace AppView.IServices
{
    public interface IHoaDonCTServices
    {
        public bool CreateProduct(HoaDonCt s);
        public bool UpdateProduct(HoaDonCt s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<HoaDonCt> GetAllHoaDonCt();
        public HoaDonCt GetGioHoaDonCtById(Guid Id);
        public List<HoaDonCt> GetHoaDonCtByName(string Name);
        
    }
}
