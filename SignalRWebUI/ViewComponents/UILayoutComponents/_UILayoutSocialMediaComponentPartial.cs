using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responsesmessage = await client.GetAsync("http://localhost:5014/api/SocialMedia");
            if(responsesmessage.IsSuccessStatusCode)
            {
                var jsondata=await responsesmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsondata);
                return View(value);
            }
            return View();
        }
    }
}
