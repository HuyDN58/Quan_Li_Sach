using AppData.Models;

namespace AppView.IServices
{
    public interface INXBServices
    {
        public bool CreateProduct(Nxb s);
        public bool UpdateProduct(Nxb s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<Nxb> GetAllNxb();
        public Nxb GetNxbById(Guid Id);
        public List<Nxb> GetNxbByName(string Name);
    }
}
