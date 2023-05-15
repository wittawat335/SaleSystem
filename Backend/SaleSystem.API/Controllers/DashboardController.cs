using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _service;

        public DashBoardController(IDashBoardService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("Summary")]
        public async Task<IActionResult> Summary()
        {
            var response = new Response<DashBoardDTO>();
            try
            {
                response.value = await _service.Summary();
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }
    }
}
