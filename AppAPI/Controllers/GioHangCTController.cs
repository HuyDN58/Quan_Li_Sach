using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangCTController : ControllerBase
    {
        private IAllRepositories<GioHangCt> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public GioHangCTController()
        {
            AllRepositories<GioHangCt> repos = new AllRepositories<GioHangCt>(context, context.GioHangCts);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<GioHangCt> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public GioHangCt Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idghct == id);
        }
        [HttpPost("Create")]
        public bool Create(int soluong, int trangthai, Guid idgh, Guid idspct)
        {
            GioHangCt acc = new GioHangCt();
            acc.SoLuong = soluong; acc.TrangThai = trangthai; acc.Idspct = idspct; acc.Idgh = idgh; acc.Idghct = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, int soluong, int trangthai, Guid idgh, Guid idspct)
        {

            var acc = irepos.GetAll().First(c => c.Idghct == id);
            acc.SoLuong = soluong; acc.TrangThai = trangthai; acc.Idspct = idspct; acc.Idgh = idgh;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.GioHangCts.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
