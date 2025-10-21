using CRUDUsuarios.Aplication.usecases.User.Validations;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Exception.Exceptions;
using CRUDUsuarios.Infrastructure.DataAccess;

namespace CRUDUsuarios.Aplication.usecases.User.Delete
{
    public class DeleteUserByIdUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new CRUDUsuariosDBContext();
            Validate(id, dbContext);

            var userEntity = dbContext.users.FirstOrDefault(user => user.id == id.ToString());

            if (userEntity is null)
                throw new NotFoundException("Nenhum usuário encontrado.");

       

            dbContext.Remove(userEntity);
            dbContext.SaveChanges();
        }

        private void Validate(Guid id, CRUDUsuariosDBContext db)
        {

            var isUserExit = db.users.Any(u => u.id == id.ToString());

            if (!isUserExit)
            {
                throw new NotFoundException("Nenhum usuário encontrado.");
            }

        }
    }
}
