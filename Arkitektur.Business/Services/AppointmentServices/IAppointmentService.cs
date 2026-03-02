using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<object>> CreateAsync(CreateAppointmentDto createAppointmentDto);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto updateAppointmentDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<List<ResultAppointmentDto>> GetAllAsync();
        Task<ResultAppointmentDto> GetByIdAsync(int id);
    }
}
