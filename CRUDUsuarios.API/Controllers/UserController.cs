using CRUDUsuarios.Aplication.usecases.User.Register;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;
using CRUDUsuarios.Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortUserJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUser([FromBody] RequestRegisterUserJson user)
        {

            var usecase = new RegisterUserUseCase();
            var response = usecase.Execute(user);

            return Created(string.Empty, new { Message = "Usuario registrado com sucesso", User = response });

        }
    }
}
