using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IAllRepositories<HoaDon> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public HoaDonController()
        {
            AllRepositories<HoaDon> repos = new AllRepositories<HoaDon>(context, context.HoaDons);
            irepos = repos;
        }

        [HttpGet]
        public IEnumerable<HoaDon> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public HoaDon Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idhd == id);
        }
        [HttpPost]
        public bool CreateColor(string MaHd, Guid idKh, Guid idNv, Guid idKm)
        {
            HoaDon acc = new HoaDon();
            acc.MaHd = MaHd; acc.Idkh = idKh; acc.Idnv = idNv;
            acc.Idkm = idKm; acc.NgayTao = DateTime.Now; acc.TrangThai = 0; acc.Idhd = Guid.NewGuid();
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string MaHd, Guid idKh, Guid idNv, Guid idKm)
        {
            var acc = irepos.GetAll().First(c => c.Idhd == id);
            acc.MaHd = MaHd; acc.Idkh = idKh; acc.Idnv = idNv;
            acc.Idkm = idKm; acc.NgayTao = DateTime.Now; acc.TrangThai = 0;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.HoaDons.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
