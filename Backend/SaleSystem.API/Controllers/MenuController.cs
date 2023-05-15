using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetList(Guid userId)
        {
            var response = new Response<List<MenuDTO>>();
            try
            {
                response.value = await _menuService.GetList(userId);
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
