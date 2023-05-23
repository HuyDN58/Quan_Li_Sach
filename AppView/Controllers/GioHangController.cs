using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class GioHangController : Controller
    {
        public GioHangController()
        {

        }

        public async Task<IActionResult> ShowAllGioHang()
        {
            // Call API
            string apiUrl = "https://localhost:7273/api/GioHang";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API dạng Json
            // Đọc từ string Json vừa thu được sang double
            var gh = JsonConvert.DeserializeObject<List<GioHang>>(apiData);
            return View(gh);
        }
    }
}
