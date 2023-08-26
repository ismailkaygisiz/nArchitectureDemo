using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? CacheKey { get; }

        public string? CacheGroupKey => "GetListBrandQuery";

        public bool ByPassCache { get; }
    }
}
