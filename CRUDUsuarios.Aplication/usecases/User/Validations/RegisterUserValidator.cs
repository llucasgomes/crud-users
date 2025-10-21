using CRUDUsuarios.Comunication.Requests;
using FluentValidation;

namespace CRUDUsuarios.Aplication.usecases.User.Validations
{
    public class RegisterUserValidator: AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator() 
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");

            RuleFor(user => user.Email).NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser um endereço de email válido.");
            RuleFor(user => user.Password).NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
                .MaximumLength(50).WithMessage("A senha não pode exceder 50 caracteres.");
            //RuleFor(user => user.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            //    .WithMessage("A senha deve ter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
        }
    }
}
