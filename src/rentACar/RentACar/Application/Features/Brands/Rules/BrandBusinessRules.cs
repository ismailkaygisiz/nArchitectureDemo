using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules : BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;
        public BrandBusinessRules(IBrandRepository brandDepository)
        {
            _brandRepository = brandDepository;
        }

        protected async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            if (await _brandRepository.AnyAsync(predicate: b => b.Name == name))
                throw new BusinessException(BrandMessages.BrandNameExists);
        }

        protected async Task BrandNameCannotBeDuplicatedWithDeletedDataWhenInserted(string name)
        {
            if (await _brandRepository.AnyAsync(predicate: b => b.Name == name, withDeleted: true))
                throw new BusinessException(BrandMessages.BrandNameExistsInDeletedData);
        }
    }
}
