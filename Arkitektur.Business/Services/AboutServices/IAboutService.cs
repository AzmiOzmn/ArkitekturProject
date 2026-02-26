using Arkitektur.Business.DTOs.AboutDtos;

namespace Arkitektur.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsycn();
        Task<ResultAboutDto> GetByIdAllAsycn(int id);
        Task<ResultAboutDto> GetAllAsycn6();
    }
}
