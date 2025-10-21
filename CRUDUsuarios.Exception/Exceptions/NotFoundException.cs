using System.Net;

namespace CRUDUsuarios.Exception.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string erroMessages) : base(erroMessages) { }

        public override List<string> GetErros() => [Message];


        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound; //404
    }
}
