using iroutePrueba.Dao;
using Microsoft.EntityFrameworkCore;
using iroutePrueba.MODEL;
using System;
using System.Collections.Generic;
using iroutePrueba.Dto;
using System.Collections;

namespace iroutePrueba.BOImpl
{
    public class ClienteBOImpl
    {
        private ClienteDao objClienteDao;

        public ClienteBOImpl(DbContextOptions<MyDBContext> options)

        {
            this.objClienteDao = new ClienteDao(options);
        }

        /**
       * @author Bryan Zamora
       * @desciption Busca el cliente por identificación
       * @param strIdentificacion
       *
       */
        public List<ConsultaClientesDTO> findCliente(String strIdentificacion)
        {
            List<Clientes> lsClientes = this.objClienteDao.findCliente(strIdentificacion);
           
            //Si es diferente de null y la lista esta vacia salta la validacion
            if (!String.IsNullOrEmpty(strIdentificacion) && lsClientes.Count==0)
                throw new BOException("La identificación del cliente no es válida.");

            ConsultaClientesDTO objConsultaClientesDTO = null;
            List<ConsultaClientesDTO> lsConsultaClientesDTO = new List<ConsultaClientesDTO>();

            foreach (Clientes objClientes in lsClientes)
            {
                objConsultaClientesDTO = new ConsultaClientesDTO();
                objConsultaClientesDTO.id = objClientes.id;
                objConsultaClientesDTO.primerNombre = objClientes.PrimerNombre;
                objConsultaClientesDTO.segundoNombre = objClientes.SegundoNombre;
                objConsultaClientesDTO.apellidos = objClientes.Apellidos;
                objConsultaClientesDTO.identificacion = objClientes.Identificacion;
                objConsultaClientesDTO.mail = objClientes.Correo;
                objConsultaClientesDTO.estado = objClientes.Estado != null && objClientes.Estado == true ? 1 : 0;
                objConsultaClientesDTO.estadoDesc = objClientes.Estado != null && objClientes.Estado == true ? "Activo" : "Inactivo";
                lsConsultaClientesDTO.Add(objConsultaClientesDTO);
            }

            return lsConsultaClientesDTO;
        }

        internal object crearCliente(CrearClientesDTO objClienteDTO)
        {
            //Valida campo primer nombre requerido
            if (String.IsNullOrEmpty(objClienteDTO.primerNombre))
                throw new BOException(CampoRequerido("Primer Nombre"));

            //Valida campo apellidos requerido
            if (String.IsNullOrEmpty(objClienteDTO.apellidos))
                throw new BOException(CampoRequerido("Apellidos"));

            //Valida campo apellidos requerido
            if (String.IsNullOrEmpty(objClienteDTO.identificacion))
                throw new BOException(CampoRequerido("Identificacion"));

            if (String.IsNullOrEmpty(objClienteDTO.mail))
                throw new BOException(CampoRequerido("Mail"));

            int intCantIdentificacion = this.objClienteDao.cantidadIdentificacion(objClienteDTO.identificacion);

            //Si es diferente de null y la lista esta vacia salta la validacion
            if (intCantIdentificacion > 0)
                throw new BOException("Ya existe un cliente con dicha identificación.");

            Clientes objCliente = new Clientes();
            objCliente.PrimerNombre = objClienteDTO.primerNombre;
            objCliente.SegundoNombre = objClienteDTO.segundoNombre;
            objCliente.Apellidos = objClienteDTO.apellidos;
            objCliente.Correo = objClienteDTO.mail;
            objCliente.Identificacion = objClienteDTO.identificacion;
            objCliente.Estado = true;
            this.objClienteDao.add(objCliente);

            Dictionary<string, Object> diccResult = new Dictionary<string, Object>();
            diccResult.Add("procesoExitoso", true);
            diccResult.Add("id", objCliente.id);
            return diccResult;
        }

        /**
        * @author Bryan Zamora
        * @desciption Inactiva el cliente
        * @param id
        *
        */
        internal object inactivarCliente(int id)
        {
            //Valida campo requerido
            if (id==null || id==0)
                throw new BOException(CampoRequerido("ID"));

            Clientes objClientes = this.objClienteDao.find(id);

            //Valida que el cliente exista
            if (objClientes==null)
                throw new BOException("El ID del cliente no es válido.");

            //Valida que se encuentre activa
            if (objClientes.Estado==false)
                throw new BOException("El cliente ya se encuentra inactivo.");

            objClientes.Estado = false;
            this.objClienteDao.update(objClientes);

            Dictionary<string, Object> diccResult = new Dictionary<string, Object>();
            diccResult.Add("procesoExitoso",true);
            diccResult.Add("id",id);
            return diccResult;
        }

        internal static String CampoRequerido(String strCampo)
        {
            return "El campo "+strCampo+" es requerido.";
        }
    }
}   
