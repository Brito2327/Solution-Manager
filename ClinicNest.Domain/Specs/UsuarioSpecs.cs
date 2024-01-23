using ClinicNest.Domain.Resources;
using FluentValidation;
using ClinicNest.Domain.Util;
using ClinicNest.Domain.Entities;

namespace ClinicNest.Domain.Specs
{
    public class UsuarioSpecs : AbstractValidator<Usuario>
    {
        public UsuarioSpecs()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(UsuarioResources.ErrorLogin);
            
            RuleFor(x => x.Email)
                .Matches(RegexPatterns.Email);

        }
    }
}
