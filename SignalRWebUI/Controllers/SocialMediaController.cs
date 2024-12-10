using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.SocialMediaDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responsesmessage = await client.GetAsync("http://localhost:5014/api/SocialMedia");
            if(responsesmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsesmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client= _httpClientFactory.CreateClient();  
            var jsondata=JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsondata);
            var responsesmessage = await client.PostAsync("http://localhost:5014/api/SocialMedia", stringContent);
            if(responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsesmessage = await client.GetAsync($"http://localhost:5014/api/SocialMedia/{id}");
            if(responsesmessage.IsSuccessStatusCode)
            {
                var jsondata=await responsesmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsondata);
                return View(values);
               
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responsesmeesage = await client.PutAsync("http://localhost:5014/api/SocialMedia", stringContent);
            if(responsesmeesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsesmessage = await client.DeleteAsync($"http://localhost:5014/api/SocialMedia/{id}");
            if(responsesmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
