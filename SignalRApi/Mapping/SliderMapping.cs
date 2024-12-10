﻿using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SliderMapping : Profile
	{
		public SliderMapping()
		{
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
		}
	}
}
