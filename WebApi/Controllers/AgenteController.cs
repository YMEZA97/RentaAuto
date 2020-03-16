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
    public class AgenteController : BaseAPIController
    {
        #region Field
        [Dependency]
        public IAgenteServices agenteServices { get; set; }
        #endregion

        public AgenteController(IAgenteServices _agenteServices)
        {
            this.agenteServices = _agenteServices;
        }
        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = agenteServices.GetAll();
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
                var data = agenteServices.GetbyId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");

            }
        }

        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Agente a)
        {
            try
            {
                var exist = agenteServices.Exist(a.Nombre);

                if (exist) return BadRequest("Base ya Existe");

                var data = agenteServices.save(a);

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

        public ActionResult update([FromBody] Agente a)
        {
            try
            {
                var exist = agenteServices.GetbyId(a.IdAgente);
                if (exist == null) return BadRequest("No se encontro el registro");
                var data = agenteServices.Update(a);
                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}