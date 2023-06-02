using AppData.Models;

namespace AppView.IServices
{
    public interface IAccountServices
    {
        public bool CreateProduct(Account s);
        public bool UpdateProduct(Account s);
        public bool DeleteProduct(Guid Id); // tên kiểu trả về tham số truyền vào
        public List<Account> GetAllAccount();
        public Account GetAccountById(Guid Id);
        public List<Account> GetAccountName(string Name);
    }
}
