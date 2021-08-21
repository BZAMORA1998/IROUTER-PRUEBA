using Microsoft.EntityFrameworkCore;
using iroutePrueba.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

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


        /**
        * @author Bryan Zamora
        * @desciption Busca el cliente por identificación
        * @param strIdentificacion
        *
        */
        internal List<Clientes> findCliente(string strIdentificacion)
        {

            List<Clientes> lsClientes=null;
            //Si el tipo de identificacion es null o vacio trae toda la lista
            if (String.IsNullOrEmpty(strIdentificacion))
            {
                lsClientes = context.clientes.OrderBy(s => s.Apellidos).ToList();
            }
            else
            {
                lsClientes = context.clientes.Where(cliente=> cliente.Identificacion==strIdentificacion).ToList();
            }

            return lsClientes;
        }

        /**
       * @author Bryan Zamora
       * @desciption Busca el cliente por identificación
       * @param strIdentificacion
       *
       */
        internal int cantidadIdentificacion(string strIdentificacion)
        {
            int intCount= context.clientes
                .Where(cliente => cliente.Identificacion == strIdentificacion).Count();
            return intCount;
        }
    }
}
