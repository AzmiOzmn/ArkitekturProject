using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Mapster;

namespace Arkitektur.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> aboutRepository, IUnitOfWork unitOfWork) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto createAboutDto)
        {
            var about = createAboutDto.Adapt<About>();
            await aboutRepository.AddAsync(about);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(about) : BaseResult<object>.Failure("Failed to create about.");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<object>.Failure("About Not Found");
            }
            aboutRepository.Delete(about);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Failure("Failed to delete about.");
           

        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsycn()
        {
            var abouts = await aboutRepository.GetAllAsycn();
            var result = abouts.Adapt<List<ResultAboutDto>>();
            return BaseResult<List<ResultAboutDto>>.Success(result);
        }

        public async Task<BaseResult<ResultAboutDto>> GetByIdAllAsycn(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<ResultAboutDto>.Failure("About Not Found");
            }
            var result = about.Adapt<ResultAboutDto>();
            return BaseResult<ResultAboutDto>.Success(result);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var about = updateAboutDto.Adapt<About>();
            aboutRepository.Update(about);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(about) : BaseResult<object>.Failure("Failed to update about.");
        }
    }
}
