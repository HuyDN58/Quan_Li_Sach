using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private readonly ILogger<KhuyenMaiController> _logger;
        public KhuyenMaiController(ILogger<KhuyenMaiController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KhuyenMai s)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["MaKm"] = s.MaKm,
                ["NgayBd"] = Convert.ToString(s.NgayBd),
                ["NgayKt"] = Convert.ToString(s.NgayKt),
                ["PhanTramGiam"] = Convert.ToString(s.PhanTramGiam),
                ["TrangThai"] = Convert.ToString(s.TrangThai),
            };
            string apiUrl = QueryHelpers.AddQueryString("https://localhost:7273/api/KhuyenMai/Create", data);
            HttpResponseMessage response = await client.PostAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAllPromotion");
            }
            else return View(s);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            string apiUrl = $"https://localhost:7273/api/KhuyenMai/{Id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<KhuyenMai>(apiData);
            return View(p);

        }

        public async Task<IActionResult> Edit(KhuyenMai p)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["Idkm"] = p.Idkm.ToString(),
                ["MaKm"] = p.MaKm,
                ["NgayBd"] = p.NgayBd.ToString(),
                ["NgayKt"] = p.NgayKt.ToString(),
                ["PhanTramGiam"] = p.PhanTramGiam.ToString(),
                ["TrangThai"] = p.TrangThai.ToString(),
            };
            string apiUrl = QueryHelpers.AddQueryString($"https://localhost:7273/api/KhuyenMai/{p.Idkm}", data);
            HttpResponseMessage response = await client.PutAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAllPromotion");
            }
            else return View(p);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://localhost:7273/api/KhuyenMai/{Id}";
            HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            return RedirectToAction("ShowAllPromotion");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            string apiUrl = $"https://localhost:7273/api/KhuyenMai/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<KhuyenMai>(apiData);
            return View(p);
        }
        public async Task<IActionResult> ShowAllPromotion()
        {
            // Call API
            string apiUrl = "https://localhost:7273/api/KhuyenMai";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API dạng Json
            // Đọc từ string Json vừa thu được sang double
            var promotion = JsonConvert.DeserializeObject<List<KhuyenMai>>(apiData);
            return View(promotion);
        }

    }
}
