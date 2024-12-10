using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstarct;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCasesService _moneyCasesService;

        public MoneyCasesController(IMoneyCasesService moneyCasesService)
        {
            _moneyCasesService = moneyCasesService;
        }

        [HttpGet("TotalMoneyCases")]
        public IActionResult TotalMoneyCases()
        {
          var val= _moneyCasesService.TTotalMoneyCases();
            return Ok(val);
        }
    }
}
