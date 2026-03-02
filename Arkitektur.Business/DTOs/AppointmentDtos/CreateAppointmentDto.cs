using Arkitektur.Entity.Enums;

namespace Arkitektur.Business.DTOs.AppointmentDtos
{
    public record CreateAppointmentDto(string NameSurnmename, string Email, string PhoneNumber, string ServiceName, DateTime AppointmentDate, string Message, AppointmentStatus Status = 0)
    {
    }
}
