using iroutePrueba.Dao;
using Microsoft.EntityFrameworkCore;
using System;

namespace iroutePrueba.BOImpl
{
    public class ClienteBOImpl
    {
        private ClienteDao objClienteDao;

        public ClienteBOImpl(DbContextOptions<MyDBContext> options)

        {
            this.objClienteDao = new ClienteDao(options);
        }

        public object consultaCliente(String strIdentificacion)
        {
            return this.objClienteDao.findCliente(strIdentificacion);
        }
    }
}
