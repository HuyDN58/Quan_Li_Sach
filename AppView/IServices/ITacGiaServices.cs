using AppData.Models;

namespace AppView.IServices
{
    public interface ITacGiaServices
    {
        public bool CreateProduct(TacGia s);
        public bool UpdateProduct(TacGia s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<TacGia> GetAllTacGia();
        public TacGia GetTacGiaById(Guid Id);
        public List<TacGia> GetTacGiaByName(string Name);
    }
}
