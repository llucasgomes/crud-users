using CRUDUsuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsuarios.Infrastructure.DataAccess
{
    public class CRUDUsuariosDBContext: DbContext
    {

        public DbSet<UserDto> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=aws-1-us-east-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.nmvokawurdgmzuwlcmlm;Password=k$9#q63?KpuB2-Q");

        }

    }
}
