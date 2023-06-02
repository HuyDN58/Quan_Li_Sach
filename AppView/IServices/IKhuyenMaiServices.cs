using AppData.Models;

namespace AppView.IServices
{
    public interface IKhuyenMaiServices
    {
        public bool CreateProduct(KhuyenMai s);
        public bool UpdateProduct(KhuyenMai s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<KhuyenMai> GetAllKhuyenMai();
        public KhuyenMai GetKhuyenMaiById(Guid Id);
        public List<KhuyenMai> GetKhuyenMaiByName(string Name);
    }
}