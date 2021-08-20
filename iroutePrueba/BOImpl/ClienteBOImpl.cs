using iroutePrueba.Dao;
using Microsoft.EntityFrameworkCore;

namespace iroutePrueba.BOImpl
{
    public class ClienteBOImpl
    {
        private ClienteDao objClienteDao;

        public ClienteBOImpl(DbContextOptions<MyDBContext> options)

        {
            this.objClienteDao = new ClienteDao(options);
        }

        public object consultaCliente(int id)
        {
            return this.objClienteDao.find(id);
        }
    }
}
