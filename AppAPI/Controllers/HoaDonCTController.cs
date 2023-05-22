using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonCTController : ControllerBase
    {
        private IAllRepositories<HoaDonCt> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public HoaDonCTController()
        {
            AllRepositories<HoaDonCt> repos = new AllRepositories<HoaDonCt>(context, context.HoaDonCts);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<HoaDonCt> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public HoaDonCt Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idhdct == id);
        }
        [HttpPost("Create")]
        public bool Create(int soluong, int trangthai, Guid idhd, Guid idspct)
        {
            HoaDonCt acc = new HoaDonCt();
            acc.SoLuong = soluong; acc.TrangThai = trangthai; acc.Idspct = idspct; acc.Idhd = idhd; acc.Idhdct = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, int soluong, int trangthai, Guid idhd, Guid idspct)
        {

            var acc = irepos.GetAll().First(c => c.Idhdct == id);
            acc.SoLuong = soluong; acc.TrangThai = trangthai; acc.Idspct = idspct; acc.Idhd = idhd;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.HoaDonCts.Find(id);
            return irepos.DeleteItem(acc);
        }
    }

}
