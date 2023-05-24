using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private IAllRepositories<KhuyenMai> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public KhuyenMaiController()
        {
            AllRepositories<KhuyenMai> repos =
                new AllRepositories<KhuyenMai>(context, context.KhuyenMais);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<KhuyenMai> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public KhuyenMai Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idkm == id);
        }
        [HttpPost("Create")]
        public bool Create(string MaKm, DateTime NgayBd, DateTime NgayKt, int PhanTramGiam, int? trangthai)
        {
            KhuyenMai promtion = new KhuyenMai();
            promtion.MaKm = MaKm; promtion.NgayBd = NgayBd; promtion.NgayKt = NgayKt; promtion.PhanTramGiam = PhanTramGiam; promtion.TrangThai = trangthai;
            return irepos.CreateItem(promtion);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid Idkm, string MaKm, DateTime NgayBd, DateTime NgayKt, int PhanTramGiam, int trangthai)
        {

            var promotion = irepos.GetAll().First(c => c.Idkm == Idkm);
            promotion.Idkm = Idkm; promotion.MaKm = MaKm; promotion.NgayBd = NgayBd; promotion.NgayKt = NgayKt; promotion.PhanTramGiam = PhanTramGiam; promotion.TrangThai = trangthai;
            return irepos.UpdateItem(promotion);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var promotion = context.KhuyenMais.Find(id);
            return irepos.DeleteItem(promotion);
        }
    }
}
