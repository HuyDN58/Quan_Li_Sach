using AppData.Models;
using AppView.IServices;
using AppView.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace AppView.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ILogger<SanPhamController> _logger;
        private readonly ISanPhamServices sanPhamServices;
        public SanPhamController(ILogger<SanPhamController> logger)
        {
            _logger = logger;
            sanPhamServices = new SanPhamServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       /* public IActionResult ShowList()
        {

            List<SanPham> sanPhams = sanPhamServices.GetAllSanPham();
            return View(sanPhams);
        }*/
        public IActionResult Create()
        {
            return View();// Hiện thị view
        }
        [HttpPost]
        public IActionResult Create(SanPham s) 
        {
            if (sanPhamServices.CreateProduct(s)) // tajoo mới
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            // Lấy product từ daatabase dwuja theo id truyền vào từ route
            SanPham p = sanPhamServices.GetSanPhamById(Id); // Hiện thị view
            return View(p);

        }

        public IActionResult Edit(SanPham p)
        {
            if (sanPhamServices.UpdateProduct(p)) // tajoo mới
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid Id)
        {

            if (sanPhamServices.DeleteProduct(Id))
            {
                return RedirectToAction("ShowAll");

            }
            else return View("Index");

        }
        public IActionResult Details(Guid id)
        {
            QUAN_LI_SACH_NET105Context shopDbContext = new QUAN_LI_SACH_NET105Context();
            var product = shopDbContext.SanPhams.Find(id);
            return View(product);
        }

        public async Task<IActionResult> ShowAll()
        {
        // Call API
        string apiUrl = "https://localhost:7273/api/SanPham";
        var httpClient = new HttpClient(); // tạo ra để callApi
        var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
        string apiData = await response.Content.ReadAsStringAsync();
        // Lấy kqua trả về từ API dạng Json
        // Đọc từ string Json vừa thu được sang double
        var colors = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
        return View(colors);
        }
    }
}
