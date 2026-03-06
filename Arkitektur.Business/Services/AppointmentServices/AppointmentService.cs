using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IGenericRepository<Appointment> repository, IUnitOfWork unitOfWork, IValidator<Appointment> createValidator) : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = createAppointmentDto.Adapt<Appointment>();
            var validationResult = await createValidator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Failure(validationResult.Errors);
            }
            await repository.AddAsync(appointment);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Failure("Failed to create appointment.");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment = await repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<object>.Failure("Appointment not found.");
            }
            repository.Delete(appointment);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Failure("Failed to delete appointment.");

        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            var appointments = await repository.GetAllAsycn();
            var mappedResults = appointments.Adapt<List<ResultAppointmentDto>>();
            return BaseResult<List<ResultAppointmentDto>>.Success(mappedResults);
        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
          var appointment = await repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<ResultAppointmentDto>.Failure("Appointment not found.");
            }
            var mappedResult = appointment.Adapt<ResultAppointmentDto>();
            return BaseResult<ResultAppointmentDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = updateAppointmentDto.Adapt<Appointment>();
            var validationResult = await createValidator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Failure(validationResult.Errors);
            }
            repository.Update(appointment);
            var result = await unitOfWork.SaveChangesAsycn();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Failure("Failed to update appointment.");
        }

       
       
    }
}
