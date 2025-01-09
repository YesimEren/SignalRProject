using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstarct;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			var values=_notificationService.TGetAllList();
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var values=_notificationService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdNotificationDto>(values));
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			var values = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(values);
			return Ok("Bildirim eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var values = _notificationService.TGetByID(id);
			_notificationService.TDelete(values);
			return Ok();


		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var values=_mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(values);
			return Ok("Güncelleme yapıldı");
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}

		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme yapıldı");
		}

		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme yapıldı");
		}


	}
}
