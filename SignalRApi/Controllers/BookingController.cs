using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SignalR.BusinessLayer.Abstarct;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values=_bookingService.TGetAllList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.TGetByID(id);
            return Ok(value);
        }

       

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validatorResult=_validator.Validate(createBookingDto);
            if(!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            Booking booking = new Booking()
            {
              Name=createBookingDto.Name,
              Phone=createBookingDto.Phone,
              Mail=createBookingDto.Mail,
              PersonCount=createBookingDto.PersonCount,
              Date=createBookingDto.Date,
              Description=createBookingDto.Description

            };
            _bookingService.TAdd(booking);

            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values=_bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date,
                Description = updateBookingDto.Description

            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
    }
}
