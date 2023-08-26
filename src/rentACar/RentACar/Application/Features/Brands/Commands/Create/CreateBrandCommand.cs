using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ICacheRemoverRequest, ILoggableRequest
    {
        public string Name { get; set; }

        public string? CacheKey { get; }

        public string? CacheGroupKey => "GetListBrandQuery";

        public bool ByPassCache { get; }
    }
}
