using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private IAllRepositories<NhanVien> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public NhanVienController()
        {
            AllRepositories<NhanVien> repos = new AllRepositories<NhanVien>(context, context.NhanViens);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public NhanVien Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idnv == id);
        }
        [HttpPost("Create")]


        public bool Create(string MaNv, string TenNv,string Sdt, string DiaChi, Guid IDNguoiDung, int TrangThai)
        {
            NhanVien acc = new NhanVien();
            acc.MaNv = MaNv; 
            acc.TenNv = TenNv; 
            acc.Sdt = Sdt;
            acc.DiaChi = DiaChi;
            acc.IdnguoiDung = IDNguoiDung;
            acc.TrangThai = TrangThai;
            return irepos.CreateItem(acc);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string MaNv, string TenNv, string Sdt, string DiaChi, Guid IDNguoiDung, int TrangThai)
        {
            var acc = irepos.GetAll().First(c => c.Idnv == id);
            acc.MaNv = MaNv;
            acc.TenNv = TenNv;
            acc.Sdt = Sdt;
            acc.DiaChi = DiaChi;
            acc.IdnguoiDung = IDNguoiDung;
            acc.TrangThai = TrangThai;
            return irepos.UpdateItem(acc);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var acc = context.NhanViens.Find(id);
            return irepos.DeleteItem(acc);
        }
    }
}
