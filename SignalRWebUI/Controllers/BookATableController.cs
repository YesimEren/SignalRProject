using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5014/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values.Select(x => x.Location).FirstOrDefault();
            }
            return View();
        }

        [HttpPost]
    
        public async Task< IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client2.GetAsync("http://localhost:5014/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values.Select(x => x.Location).FirstOrDefault();
            }

            var client=_httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsondata,Encoding.UTF8, "application/json");
            var responsesmessage = await client.PostAsync("http://localhost:5014/api/Booking", content);
            if(responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }
        }
    }
}
