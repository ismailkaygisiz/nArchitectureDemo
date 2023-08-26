using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string? CacheKey { get; }

        public string? CacheGroupKey => "GetListBrandQuery";

        public bool ByPassCache { get; }
    }
}
