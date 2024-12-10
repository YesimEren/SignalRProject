using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstarct;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService,IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;

        }
        [HttpGet("MenuTableList")]
        public ActionResult MenuTableList()
        {
            var values=_menuTableService.TGetAllList();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var value = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(value);
            return Ok("Masa Başarılı Bir Şekilde Eklendi");
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteMenuTable(int id)
        {
           var values= _menuTableService.TGetByID(id);  
            _menuTableService.TDelete(values);
            return Ok("Masa Silindi");
        }

        [HttpPut]
        public ActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var values = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(values);
            return Ok("Masa Bilgisi Güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetByIdMenuTable(int id)
        {
            var values=_menuTableService.TGetByID(id);
            return Ok(_mapper.Map<GetMenuTableDto>(values));
        }


        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
             _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("İşlem başarılı");
        }


        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("İşlem başarılı");
        }
    }
}
