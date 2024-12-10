using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responsesmmesage = await client.GetAsync("http://localhost:5014/api/Slider");
            if(responsesmmesage.IsSuccessStatusCode)
            {
                var jsondata=await responsesmmesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsondata);
                return View(values);
            }
           
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(createSliderDto);
			StringContent content=new StringContent(jsondata, Encoding.UTF8, "application/json");
			var values = await client.PostAsync("http://localhost:5014/api/Slider", content);
			if(values.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
            return View();
        }

		
		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responsesmessage = await client.DeleteAsync($"http://localhost:5014/api/Slider/{id}");
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSlider()
		{
			var client = _httpClientFactory.CreateClient();
			var responsesmmesage = await client.GetAsync("http://localhost:5014/api/Slider");
			if (responsesmmesage.IsSuccessStatusCode)
			{
				var jsondata = await responsesmmesage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsondata);
				return View(values);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata=JsonConvert.SerializeObject(updateSliderDto);
			StringContent stringcontent = new StringContent(jsondata,Encoding.UTF8, "application/json");
			var responsesmessage = await client.PutAsync("http://localhost:5014/api/Slider", stringcontent);
			if(responsesmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
