using iroutePrueba.BOImpl;
using iroutePrueba.Dao;
using iroutePrueba.DTO;
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


        [HttpGet("{id}")]
        public Object consultaTipoIdentificacion(int id)
        {
            try
            {
                return new Response200("ok",this.objClienteBOImpl.consultaCliente(id));
            }
            catch (BOException e)
            {
                return new ResponseError(400, e.Message, e.Data);
            }
            catch (Exception e)
            {
                return new ResponseError(500, e.Message, e.Data);
            }
        }
    }
}
