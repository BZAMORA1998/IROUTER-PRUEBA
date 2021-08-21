using Microsoft.EntityFrameworkCore;
using iroutePrueba.MODEL;

namespace iroutePrueba.Dao
{
    public class MyDBContext : DbContext
    {
        public DbSet<Clientes> clientes { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
    }
}
