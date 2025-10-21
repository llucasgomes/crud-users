using CRUDUsuarios.Aplication.usecases.User.GetAllUsers;
using CRUDUsuarios.Aplication.usecases.User.GetUserById;
using CRUDUsuarios.Aplication.usecases.User.Register;
using CRUDUsuarios.Comunication.Requests;
using CRUDUsuarios.Comunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUser([FromBody] RequestRegisterUserJson user)
        {

            var usecase = new RegisterUserUseCase();

            var response = usecase.Execute(user);

            return Created(string.Empty, new { Message = "Usuario registrado com sucesso", User = response });

        }

        [HttpGet]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseListShortUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllUsers()
        {
            var usecase = new GetAllUserUseCase();

            var response = usecase.Execute();

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseShortUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUseById([FromRoute] Guid id,[FromBody] RequestRegisterUserJson updateData)
        {
            var usecase = new UpdateUserUseCase();
            var response = usecase.Execute(id, updateData);

           

            return Ok(response);
        }
    }
}
