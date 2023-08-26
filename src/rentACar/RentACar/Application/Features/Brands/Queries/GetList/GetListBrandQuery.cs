using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest, ILoggableRequest
    {
        public PageRequest? PageRequest { get; set; } = new();

        public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";

        public bool ByPassCache { get; }

        public TimeSpan? SlidingExpiration { get; }

        public string? CacheGroupKey => $"GetListBrandQuery";
    }
}
