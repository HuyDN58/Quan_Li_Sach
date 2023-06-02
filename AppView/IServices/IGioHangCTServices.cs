using AppData.Models;

namespace AppView.IServices
{
    public interface IGioHangCTServices
    {
        public bool CreateProduct(GioHangCt s);
        public bool UpdateProduct(GioHangCt s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<GioHangCt> GetAllGioHangCt();
        public GioHangCt GetGioHangCtById(Guid Id);
        public List<GioHangCt> GetGioHangCtByName(string Name);
    }
}
