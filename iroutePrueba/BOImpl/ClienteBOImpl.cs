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

        public List<ConsultaClientesDTO> findCliente(String strIdentificacion)
        {
            List<Clientes> lsClientes = this.objClienteDao.findCliente(strIdentificacion);
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
    }
}
