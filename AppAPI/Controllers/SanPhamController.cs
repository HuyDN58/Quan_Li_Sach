using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private IAllRepositories<SanPham> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public SanPhamController()
        {
            AllRepositories<SanPham> repos = new AllRepositories<SanPham>(context, context.SanPhams);
            irepos = repos;
        }

        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public SanPham Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idsp == id);
        }
        [HttpPost("Create-SanPham")]
        public bool Create(string MaSp, string TenSp)
        {
            SanPham acc = new SanPham();
            acc.MaSp = MaSp; acc.TenSp = TenSp; acc.Idsp = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string MaSp, string TenSp)
        {
            var acc = irepos.GetAll().First(c => c.Idsp == id);
            acc.MaSp = MaSp; acc.TenSp = TenSp; ;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.SanPhams.Find(id);
            return irepos.DeleteItem(acc);
        }
        /**/
    }
}
