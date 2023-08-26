using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
