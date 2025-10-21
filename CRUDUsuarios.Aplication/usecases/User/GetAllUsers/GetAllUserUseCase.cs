using CRUDUsuarios.Comunication.Responses;
using CRUDUsuarios.Infrastructure.DataAccess;

namespace CRUDUsuarios.Aplication.usecases.User.GetAllUsers
{
    public class GetAllUserUseCase
    {

        public  List<ResponseShortUserJson> Execute()
        {

            var dbContext = new CRUDUsuariosDBContext();

            var users = dbContext.users.Select(u => new ResponseShortUserJson
            {
                Id = Guid.Parse(u.id),
                Name = u.name,
                Email = u.email
            }).ToList();

            return users;



        }
    }
}
