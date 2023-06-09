using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class TacGiaController : Controller
    {
        private readonly ILogger<TacGiaController> _logger;
        public TacGiaController(ILogger<TacGiaController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TacGia s)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["Matg"] = s.Matg,
                ["TenTg"] = s.TenTg
            };
            string apiUrl = QueryHelpers.AddQueryString("https://localhost:7273/api/TacGia/Create", data);
            HttpResponseMessage response = await client.PostAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAll");
            }
            else return View(s);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            string apiUrl = $"https://localhost:7273/api/TacGia/{Id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<TacGia>(apiData);
            return View(p);

        }

        public async Task<IActionResult> Edit(TacGia p)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["Idtg"] = p.Idtg.ToString(),
                ["Matg"] = p.Matg,
                ["TenTg"] = p.TenTg
            };
            string apiUrl = QueryHelpers.AddQueryString($"https://localhost:7273/api/TacGia/{p.Idtg}", data);
            HttpResponseMessage response = await client.PutAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAll");
            }
            else return View(p);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://localhost:7273/api/TacGia/{Id}";
            HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            return RedirectToAction("ShowAll");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            string apiUrl = $"https://localhost:7273/api/TacGia/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<TacGia>(apiData);
            return View(p);
        }
        public async Task<IActionResult> ShowAll()
        {
            // Call API
            string apiUrl = "https://localhost:7273/api/TacGia";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API dạng Json
            // Đọc từ string Json vừa thu được sang double
            var colors = JsonConvert.DeserializeObject<List<TacGia>>(apiData);
            return View(colors);
        }
    }
}
