using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.SliderDto;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {

		private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responsesmmesage = await client.GetAsync("http://localhost:5014/api/Slider");
				var jsondata = await responsesmmesage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsondata);
				return View(values);
			
		}
    }
}
