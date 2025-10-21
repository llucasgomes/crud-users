using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;

namespace CRUDUsuarios.Aplication.usecases.User.Register
{
    public class RegisterUserUseCase
    {
        public  ResponseShortUserJson Execute(RequestRegisterUserJson user)
        {
            return new ResponseShortUserJson
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
