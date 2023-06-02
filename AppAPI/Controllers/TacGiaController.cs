using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private IAllRepositories<TacGia> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public TacGiaController()
        {
            AllRepositories<TacGia> repos = new AllRepositories<TacGia>(context, context.TacGia);
            irepos = repos;
        }

        [HttpGet]
        public IEnumerable<TacGia> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TacGia Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idtg == id);
        }
        [HttpPost("Create-mausac")]
        public bool CreateColor(string Matg, string Tentg)
        {
            TacGia acc = new TacGia();
            acc.Matg = Matg; acc.TenTg = Tentg; acc.Idtg = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string Matg, string Tentg)
        {
            var acc = irepos.GetAll().First(c => c.Idtg == id);
            acc.Matg = Matg; acc.TenTg = Tentg; ;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.TacGia.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
