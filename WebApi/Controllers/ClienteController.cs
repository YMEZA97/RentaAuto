using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Unity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class ClienteController : BaseAPIController
    {
        #region Field
        [Dependency]
        public IClienteServices clienteServices { get; set; }
        #endregion

        public ClienteController(IClienteServices _clienteServices)
        {
            this.clienteServices = _clienteServices;
        }
        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = clienteServices.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");

            }
        }

        [HttpGet]
        [ActionName("getbyid")]
        public IActionResult getbyid([FromQuery] int id)
        {
            try
            {
                var data = clienteServices.GetbyId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");

            }
        }

        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Cliente c)
        {
            try
            {
                var exist = clienteServices.Exist(c.Nombre);

                if (exist) return BadRequest("Base ya Existe");

                var data = clienteServices.save(c);

                if (data) return Created("", data);
                else return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");

            }
            return BadRequest();
        }


        [HttpPost]
        [ActionName("update")]

        public ActionResult update([FromBody] Cliente c)
        {
            try
            {
                var exist = clienteServices.GetbyId(c.IdCliente);
                if (exist == null) return BadRequest("No se encontro el registro");
                var data = clienteServices.Update(c);
                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
