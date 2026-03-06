using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email are required.")
                   .EmailAddress().WithMessage("Please enter a valid email address.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.NameSurnmename).NotEmpty().WithMessage("Name and surname are required.")
                .MinimumLength(3).WithMessage("Full name must be at least 3 characters long.");
                RuleFor(x => x.Message).NotEmpty().WithMessage("Message is not required.");
        }
    }
}
