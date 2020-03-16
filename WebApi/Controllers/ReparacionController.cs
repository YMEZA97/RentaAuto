using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Business;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Unity;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReparacionController : BaseAPIController
    {
        #region Field
        [Dependency]
        public IReparacionServices reparacionServices { get; set; }
        #endregion
        public ReparacionController(IReparacionServices _reparacionServices)
        {
            this.reparacionServices = _reparacionServices;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = reparacionServices.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpGet]
        [ActionName("getbyid")]
        public ActionResult getbyid([FromQuery] int id)
        {
            try
            {
                var data = reparacionServices.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Reparacion r)
        {
            try
            {
                var exist = reparacionServices.Exist(r.IdAuto);

                if (exist) return BadRequest("Reparacion ya existe");

                var data = reparacionServices.Save(r);

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
        public ActionResult update([FromBody] Reparacion r)
        {
            try
            {
                var exist = reparacionServices.GetById(r.IdReparacion);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = reparacionServices.Update(r);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
