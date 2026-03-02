using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Validators.AppointmentValidators;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IGenericRepository<Appointment> repository, IUnitOfWork unitOfWork, IValidator<CreateAppointmentDto> createValidator) : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = createAppointmentDto.Adapt<Appointment>();
            var validationResult = await createValidator.ValidateAsync(createAppointmentDto);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Failure(validationResult.Errors.ToString());
            }
            await repository.AddAsync(appointment);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Failure("Failed to create appointment.");
        }

        public Task<BaseResult<object>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAppointmentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultAppointmentDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto updateAppointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
