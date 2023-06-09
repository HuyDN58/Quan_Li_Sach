using AppData.Models;
using AppView.IServices;
using AppView.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
  

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account s)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["TaiKhoan"] = s.TaiKhoan,
                ["MatKhau"] = s.MatKhau
            };
            string apiUrl = QueryHelpers.AddQueryString("https://localhost:7273/api/Account/Create", data);
            HttpResponseMessage response = await client.PostAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAllAcc");
            }
            else return View(s);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            string apiUrl = $"https://localhost:7273/api/Account/{Id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<Account>(apiData);
            return View(p);

        }

        public async Task<IActionResult> Edit(Account p)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["IdnguoiDung"] = p.IdnguoiDung.ToString(),
                ["TaiKhoan"] = p.TaiKhoan,
                ["MatKhau"] = p.MatKhau
            };
            string apiUrl = QueryHelpers.AddQueryString($"https://localhost:7273/api/Account/{p.IdnguoiDung}", data);
            HttpResponseMessage response = await client.PutAsync(apiUrl, null);
            if ((await response.Content.ReadAsStringAsync()) == "true")
            {
                return RedirectToAction("ShowAllAcc");
            }
            else return View(p);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://localhost:7273/api/Account/{Id}";
            HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            return RedirectToAction("ShowAllAcc");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            string apiUrl = $"https://localhost:7273/api/Account/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<Account>(apiData);
            return View(p);
        }
        public async Task<IActionResult> ShowAllAcc()
        {
            // Call API
            string apiUrl = "https://localhost:7273/api/Account";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API dạng Json
            // Đọc từ string Json vừa thu được sang double
            var accs = JsonConvert.DeserializeObject<List<Account>>(apiData);
            return View(accs);
        }
        

    }
}
