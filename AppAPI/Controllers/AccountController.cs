using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppData.IRepositories;
using AppData.Repositories;
using AppData.Models;
using System.Drawing;


namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAllRepositories<Account> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public AccountController()
        {
            AllRepositories<Account> repos = new AllRepositories<Account>(context, context.Accounts);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Account Get(Guid id)
        {
            return irepos.GetAll().First(c => c.IdnguoiDung == id);
        }
        [HttpPost("Create")]
        public bool CreateColor(string taiKhoan, string matKhau)
        {
            Account acc = new Account();
            acc.TaiKhoan = taiKhoan; acc.MatKhau = matKhau; acc.IdnguoiDung = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string taiKhoan, string matKhau)
        {
            var acc = irepos.GetAll().First(c => c.IdnguoiDung == id);
            acc.TaiKhoan = taiKhoan; acc.MatKhau = matKhau; ;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.Accounts.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
