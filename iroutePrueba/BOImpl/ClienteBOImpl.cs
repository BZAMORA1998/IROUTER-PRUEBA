﻿using iroutePrueba.Dao;
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
                throw new BOException("No existe cliente con dicha identificación.");

            ConsultaClientesDTO objConsultaClientesDTO = null;
            List<ConsultaClientesDTO> lsConsultaClientesDTO = new List<ConsultaClientesDTO>();

            foreach (Clientes objClientes in lsClientes)
            {
                objConsultaClientesDTO = new ConsultaClientesDTO();
                objConsultaClientesDTO.id = objClientes.id;
                objConsultaClientesDTO.primerNombre = objClientes.primerNombre;
                objConsultaClientesDTO.segundoNombre = objClientes.segundoNombre;
                objConsultaClientesDTO.apellidos = objClientes.apellidos;
                objConsultaClientesDTO.identificacion = objClientes.identificacion;
                objConsultaClientesDTO.mail = objClientes.correo;
                objConsultaClientesDTO.estado = objClientes.estado != null && objClientes.estado == true ? 1 : 0;
                objConsultaClientesDTO.estadoDesc = objClientes.estado != null && objClientes.estado == true ? "Activo" : "Inactivo";
                lsConsultaClientesDTO.Add(objConsultaClientesDTO);
            }

            return lsConsultaClientesDTO;
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
            if (objClientes.estado==false)
                throw new BOException("El cliente ya se encuentra inactivo.");

            objClientes.estado = false;
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
