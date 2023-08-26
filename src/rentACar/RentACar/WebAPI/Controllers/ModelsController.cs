using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListModelQuery request)
        {
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] GetListByDynamicModelQuery request)
        {
            GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
