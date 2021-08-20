using Microsoft.EntityFrameworkCore;
using sistema_proveedor_api.MODEL;

namespace iroutePrueba.Dao
{
    public class ClienteDao
    {
        private MyDBContext context;

        public ClienteDao(DbContextOptions<MyDBContext> options)

        {
            this.context = new MyDBContext(options);
        }

        /**
         * @author Bryan Zamora
         * @desciption Busca el cliente por id
         * @param id
         *
         */
        public Clientes find(int id)
        {
            return this.context.clientes.Find(id);
        }

        /**
        * @author Bryan Zamora
        * @desciption Busca el cliente por id
        * @param objCliente
        *
        */
        public void add(Clientes objCliente)
        {
            this.context.clientes.Add(objCliente);
            this.context.SaveChanges();
        }

        /**
       * @author Bryan Zamora
       * @desciption Busca el cliente por id
       * @param objCliente
       *
       */
        public void update(Clientes objCliente)
        {
            this.context.clientes.Update(objCliente);
            this.context.SaveChanges();
        }
    }
}
