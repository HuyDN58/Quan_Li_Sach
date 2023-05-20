using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IAllRepositories<KhachHang> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public KhachHangController()
        {
            AllRepositories<KhachHang> repos = new AllRepositories<KhachHang>(context, context.KhachHangs);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public KhachHang Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idkh == id);
        }
        [HttpPost("Create-mausac")]
        public bool CreateColor(string ma, string tenkh, Guid idacc, string sdt, string diachi, int trangthai)
        {
            KhachHang kh = new KhachHang();
            kh.Ma = ma; kh.TenKh = tenkh; kh.IdnguoiDung = idacc; kh.Sdt = sdt;
            kh.DiaChi = diachi; kh.TrangThai = trangthai; kh.Idkh = Guid.NewGuid();
            return irepos.CreateItem(kh);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string ma, string tenkh, Guid idacc, string sdt, string diachi, int trangthai)
        {
            var kh = irepos.GetAll().First(c => c.Idkh == id);
            kh.Ma = ma; kh.TenKh = tenkh; kh.IdnguoiDung = idacc; kh.Sdt = sdt;
            kh.DiaChi = diachi; kh.TrangThai = trangthai;
            return irepos.UpdateItem(kh);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var kh = context.KhachHangs.Find(id);
            return irepos.DeleteItem(kh);
        }
    }
}
