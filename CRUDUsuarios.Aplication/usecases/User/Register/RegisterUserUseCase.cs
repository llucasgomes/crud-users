using CRUDUsuarios.Aplication.usecases.User.Validations;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;
using CRUDUsuarios.Domain.Entities;
using CRUDUsuarios.Exception.Exceptions;
using CRUDUsuarios.Infrastructure.DataAccess;

namespace CRUDUsuarios.Aplication.usecases.User.Register
{
    public class RegisterUserUseCase
    {
        public  ResponseShortUserJson Execute(RequestRegisterUserJson user)
        {
            var db_context = new CRUDUsuariosDBContext();

         
            Validator(user);

            var entity = new UserDto
            {
                name = user.Name,
                email = user.Email,
                password = user.Password
            };

            db_context.users.Add(entity);
            db_context.SaveChanges();



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
