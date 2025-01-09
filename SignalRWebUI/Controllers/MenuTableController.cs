using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTableDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5014/api/MenuTables/MenuTableList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadAsStringAsync();
                var jsondata = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(value);
                return View(jsondata);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createMenuTableDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsesmessage = await client.PostAsync("http://localhost:5014/api/MenuTables", content);
            if (responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsesmessage = await client.DeleteAsync($"http://localhost:5014/api/MenuTables/{id}");
            if (responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateMenuTable(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5014/api/MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMenuTableDto>(jsondata);
                return View(value);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateMenuTableDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsesmessage = await client.PutAsync("http://localhost:5014/api/MenuTables", content);
            if (responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5014/api/MenuTables/MenuTableList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
