using CRUDUsuarios.Aplication.usecases.User.Validations;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;
using CRUDUsuarios.Exception.Exceptions;
using CRUDUsuarios.Infrastructure.DataAccess;

namespace CRUDUsuarios.Aplication.usecases.User.GetUserById
{
    public class UpdateUserUseCase
    {
        public ResponseShortUserJson Execute(Guid Id, RequestRegisterUserJson updateData)
        {
            var dbContext = new CRUDUsuariosDBContext();
            Validate(Id, dbContext, updateData);

            var userEntity = dbContext.users.FirstOrDefault(user => user.id == Id.ToString());

            if (userEntity is null)
                throw new NotFoundException("Nenhum usuário encontrado.");

            userEntity.email = updateData.Email;
            userEntity.password = updateData.Password;
            userEntity.name = updateData.Name;

            dbContext.Update(userEntity);
            dbContext.SaveChanges();

            return new ResponseShortUserJson
            {
                Id = Guid.Parse(userEntity.id),
                Name = userEntity.name,
                Email = userEntity.email
            };
        }

        private void Validate(Guid id, CRUDUsuariosDBContext db, RequestRegisterUserJson updateData)
        {
            var validator = new RegisterUserValidator().Validate(updateData);

            if (!validator.IsValid)
            {
                var errors = validator.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }

            var isUserExit = db.users.Any(u => u.id == id.ToString());

            if (!isUserExit)
            {
                throw new NotFoundException("Nenhum usuário encontrado.");
            }
        }
    }
}
