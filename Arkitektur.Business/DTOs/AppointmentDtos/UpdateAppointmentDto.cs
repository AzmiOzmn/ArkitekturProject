using Arkitektur.Entity.Enums;


namespace Arkitektur.Business.DTOs.AppointmentDtos
{
    public record UpdateAppointmentDto(int Id, string NameSurnmename, string Email, string PhoneNumber, string ServiceName, DateTime AppointmentDate, string Message, AppointmentStatus Status)
    {
    
    }
}
