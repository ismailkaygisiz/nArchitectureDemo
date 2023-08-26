using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Models.Queries.GetListByDynamic
{
    public class GetListByDynamicModelQuery : IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
    {
        [FromQuery]
        public PageRequest PageRequest { get; set; } = new();

        [FromBody]
        public DynamicQuery? DynamicQuery { get; set; }
    }
}
