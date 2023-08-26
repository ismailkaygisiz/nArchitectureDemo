using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken, enableTracking: false);
            
            Brand brandToUpdate = _mapper.Map<Brand>(request);
            brandToUpdate.CreatedDate = brand.CreatedDate;

            await _brandRepository.UpdateAsync(brandToUpdate);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brandToUpdate);
            return response;
        }
    }
}
