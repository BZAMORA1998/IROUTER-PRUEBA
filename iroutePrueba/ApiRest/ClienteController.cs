using iroutePrueba.BOImpl;
using iroutePrueba.Dao;
using iroutePrueba.Dto;
using iroutePrueba.DTO;
using iroutePrueba.MODEL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace iroutePrueba.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private ClienteBOImpl objClienteBOImpl;

        public ClienteController(DbContextOptions<MyDBContext> options)
        {
            this.objClienteBOImpl = new ClienteBOImpl(options);
        }

        [HttpPost()]
        public Object crearCliente([FromBody] CrearClientesDTO objCliente)
        {
            try
            {
                return this.objClienteBOImpl.crearCliente(objCliente);
            }
            catch (Exception e)
            {
                return new ResponseError(e.Message);
            }
        }


        [HttpGet()]
        public Object findCliente(String identificacion)
        {
            try
            {
                return this.objClienteBOImpl.findCliente(identificacion);
            }
            catch (Exception e)
            {
                return new ResponseError(e.Message);
            }
        }

        [HttpPut()]
        public Object inactivarCliente(int id)
        {
            try
            {
                return this.objClienteBOImpl.inactivarCliente(id);
            }
            catch (Exception e)
            {
                return new ResponseError(e.Message);
            }
        }
    }
}
