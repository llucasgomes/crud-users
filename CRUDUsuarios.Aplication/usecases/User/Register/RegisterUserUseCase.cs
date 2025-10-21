using CRUDUsuarios.Aplication.usecases.User.Validations;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;
using CRUDUsuarios.Exception.Exceptions;

namespace CRUDUsuarios.Aplication.usecases.User.Register
{
    public class RegisterUserUseCase
    {
        public  ResponseShortUserJson Execute(RequestRegisterUserJson user)
        {
            Validator(user);


            return new ResponseShortUserJson
            {
                Name = user.Name,
                Email = user.Email
            };
        }

        private static void Validator(RequestRegisterUserJson user)
        {
            var validator = new RegisterUserValidator().Validate(user);

            if (!validator.IsValid)
            {
                var errors = validator.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
            
            // Implementar a validação aqui
        }
    }
}
