using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Azure;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand request)
        {
            CreatedBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand request)
        {
            UpdatedBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommand request)
        {
            DeletedBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListBrandQuery request)
        {
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery request)
        {
            GetByIdBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
