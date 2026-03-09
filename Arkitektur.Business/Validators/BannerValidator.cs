using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
    }
}
