using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NXBController : ControllerBase
    {
        private IAllRepositories<Nxb> irepos;
        private QUAN_LI_SACH_NET105Context context =
            new QUAN_LI_SACH_NET105Context();
        
        
        public NXBController()
        {
            AllRepositories<Nxb> repos =
                new AllRepositories<Nxb>(context, context.Nxbs);
            irepos = repos;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Nxb> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Nxb Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idnxb == id);
        }
        [HttpPost("Create-mausac")]
        public bool CreateColor(Guid id, string ma, string ten)
        {
            Nxb color = new Nxb();
            color.Mansx = ma; color.TenNxb = ten; color.Idnxb = Guid.NewGuid();
            return irepos.CreateItem(color);
        }
        [HttpPut("{id}")]
        public bool Update(Guid id, string ma, string ten)
        {
            var mau = irepos.GetAll().First(c => c.Idnxb == id);
            mau.Mansx = ma; mau.TenNxb = ten;
            return irepos.UpdateItem(mau);
        }
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var mau = context.Nxbs.Find(id);
            return irepos.DeleteItem(mau);
        }
    }
}
