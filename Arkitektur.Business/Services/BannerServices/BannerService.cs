using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.BannerServices
{
    public class BannerService(IGenericRepository<Banner> _repository , IUnitOfWork unitOfWork,IValidator<Banner> validator) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto)
        {
            var banner = createBannerDto.Adapt<Banner>();
            var validationresult = await validator.ValidateAsync(banner);
            if(!validationresult.IsValid) // Fast Fail
            {
                return BaseResult<object>.Failure(validationresult.Errors);
            }
            await _repository.AddAsync(banner);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(banner) : BaseResult<object>.Failure("Create Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var banner =  await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<object>.Failure("Banner Not Found");
            }
            _repository.Delete(banner);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Failure("Delete Failed");
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsycn()
        {
            var banners = await _repository.GetAllAsycn();
            var mappedResult = banners.Adapt<List<ResultBannerDto>>();
            return BaseResult<List<ResultBannerDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAllAsycn(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<ResultBannerDto>.Failure("Banner Not Found");
            }
            var mappedResult = banner.Adapt<ResultBannerDto>();
            return BaseResult<ResultBannerDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var banner = updateBannerDto.Adapt<Banner>();
            var validationresult = await validator.ValidateAsync(banner);
            if (!validationresult.IsValid) 
            {
                return BaseResult<object>.Failure(validationresult.Errors);
            }

            _repository.Update(banner);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Failure("Update Failed");

        }
    }
}
