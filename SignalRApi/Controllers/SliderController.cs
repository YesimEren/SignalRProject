using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstarct;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _sliderService;
		private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			var values = _sliderService.TGetAllList();
			return Ok(values);

		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var values = _mapper.Map<Slider>(createSliderDto);
			_sliderService.TAdd(values);
			return Ok("Başarıyla eklendi");

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var values = _sliderService.TGetByID(id);
			_sliderService.TDelete(values);
			return Ok("Öne Çıkan Bilgisi Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var value=_sliderService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdSliderDto>(value));
		}

		

		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			Slider slider = new Slider()
			{
				SliderID = updateSliderDto.SliderID,
				Title1 = updateSliderDto.Title1,
				Title2 = updateSliderDto.Title2,
				Title3 = updateSliderDto.Title3,
				Description1 = updateSliderDto.Description1,
				Description2 = updateSliderDto.Description2,
				Description3 = updateSliderDto.Description3,

			};
			_sliderService.TUpdate(slider);
			return Ok("Başarıyla güncellendi");
		}
	}
}
