using Arkitektur.Business.Base;
using Arkitektur.Entity.Enums;

namespace Arkitektur.Business.DTOs.AppointmentDtos
{
    public record ResultAppointmentDto : IBaseDto
    {
        public string NameSurnmename { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string ServiceName { get; init; }
        public DateTime AppointmentDate { get; init; }
        public string Message { get; init; }

        public AppointmentStatus Status { get; init; }
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
