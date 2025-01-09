using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responsesmessage = await client.GetAsync("http://localhost:5014/api/Category");
            if(responsesmessage.IsSuccessStatusCode)
            {
                var jsonData=await responsesmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
            var client=_httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(createCategoryDto);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsesmessage = await client.PostAsync("http://localhost:5014/api/Category", content);
            if(responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
			return View();
		}

       
        public async Task<IActionResult> DeleteCategory(int id) 
        {
            var client=_httpClientFactory.CreateClient();
            var responsesmmessage = await client.DeleteAsync($"http://localhost:5014/api/Category/{id}");
            if(responsesmmessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
			}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responsesmessage = await client.GetAsync($"http://localhost:5014/api/Category/{id}");
            if(responsesmessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
                return View(values);

            }
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content=new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsesmeesage = await client.PutAsync("http://localhost:5014/api/Category", content);
            if(responsesmeesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
			return View();
		}

        



    }
}
