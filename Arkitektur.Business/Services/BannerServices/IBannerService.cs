using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;

namespace Arkitektur.Business.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsycn();
        Task<BaseResult<ResultBannerDto>> GetByIdAllAsycn(int id);

        Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto);

        Task<BaseResult<object>> DeleteAsync(int id);

        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto);
    }
}
