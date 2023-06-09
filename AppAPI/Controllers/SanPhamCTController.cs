using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamCTController : ControllerBase
    {
        private IAllRepositories<SanPhamCt> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public SanPhamCTController()
        {
            AllRepositories<SanPhamCt> repos = new AllRepositories<SanPhamCt>(context, context.SanPhamCts);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<SanPhamCt> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public SanPhamCt Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idspct == id);
        }
        [HttpPost("Create")]
        public bool Create(int gianhap,int giaban, int sl,string mota,int trangthai,  Guid idtg, Guid idnxb,Guid idsp)
        {
            SanPhamCt acc = new SanPhamCt();
            acc.Idspct= Guid.NewGuid();
            acc.Idsp = idsp; acc.GiaNhap = gianhap; acc.GiaBan = giaban; acc.SoLuongTon = sl; 
            acc.GiaBan = giaban; acc.Idtg = idtg;
            acc.Idnxb = idnxb; acc.MoTa = mota; acc.TrangThai = trangthai;
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, int gianhap, int giaban, int sl, string mota, int trangthai, Guid idtg, Guid idnxb, Guid idsp)
        {

            var acc = irepos.GetAll().First(c => c.Idspct == id);
            acc.Idsp = idsp; acc.GiaNhap = gianhap; acc.GiaBan = giaban; acc.SoLuongTon = sl;
            acc.GiaBan = giaban; acc.Idtg = idtg;
            acc.Idnxb = idnxb; acc.MoTa = mota; acc.TrangThai = trangthai;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.SanPhamCts.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
