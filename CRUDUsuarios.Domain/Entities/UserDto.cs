namespace CRUDUsuarios.Domain.Entities
{
    public class UserDto
    {
        public string id { get; set; } = new Guid().ToString();
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
    }
}
