using AppData.Models;
using AppView.IServices;
using AppView.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;

namespace AppView.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ILogger<SanPhamController> _logger;
        public SanPhamController(ILogger<SanPhamController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SanPham s)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["MaSp"] = s.MaSp,
                ["TenSp"] = s.TenSp
            };
            string apiUrl = QueryHelpers.AddQueryString("https://localhost:7273/api/SanPham/Create-SanPham", data);
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
            string apiUrl = $"https://localhost:7273/api/SanPham/{Id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(p);

        }

        public async Task<IActionResult> Edit(SanPham p)
        {
            HttpClient client = new HttpClient();
            var data = new Dictionary<string, string>()
            {
                ["id"] = p.Idsp.ToString(),
                ["MaSp"] = p.MaSp,
                ["TenSp"] = p.TenSp
            };
            string apiUrl = QueryHelpers.AddQueryString($"https://localhost:7273/api/SanPham/{p.Idsp}", data);
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
            string apiUrl = $"https://localhost:7273/api/SanPham/{Id}";
            HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            return RedirectToAction("ShowAll");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            string apiUrl = $"https://localhost:7273/api/SanPham/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(p);
        }

        public async Task<IActionResult> ShowAll()
        {
            string apiUrl = "https://localhost:7273/api/SanPham";
            var httpClient = new HttpClient(); 
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var colors = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            return View(colors);
        }
    }
}
