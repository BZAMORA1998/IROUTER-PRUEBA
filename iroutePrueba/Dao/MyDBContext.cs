using Microsoft.EntityFrameworkCore;
using sistema_proveedor_api.MODEL;

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
