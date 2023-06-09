using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppData.IRepositories;
using AppData.Repositories;
using AppData.Models;
using System.Drawing;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private IAllRepositories<GioHang> irepos;
        private QUAN_LI_SACH_NET105Context context = new QUAN_LI_SACH_NET105Context();
        public GioHangController()
        {
            AllRepositories<GioHang> repos = new AllRepositories<GioHang>(context, context.GioHangs);
            irepos = repos;
        }
        
        [HttpGet]
        public IEnumerable<GioHang> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public GioHang Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Idgh == id);
        }
        [HttpPost("Create")]
        public bool CreateColor(Guid khachhang)
        {
            GioHang gh = new GioHang();
            gh.Idkh = khachhang; gh.Idgh = Guid.NewGuid();
            return irepos.CreateItem(gh);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, Guid khachhang)
        {
            var gh = irepos.GetAll().First(c => c.Idgh == id);
            gh.Idkh = khachhang;
            return irepos.UpdateItem(gh);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var gh = context.GioHangs.Find(id);
            return irepos.DeleteItem(gh);
        }
    }
}
