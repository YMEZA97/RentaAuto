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
    public class MecanicoController : BaseAPIController
    {
        #region Field
        [Dependency]
        public IMecanicoServices mecanicoServices { get; set; }
        #endregion
        public MecanicoController(IMecanicoServices _mecanicoServices)
        {
            this.mecanicoServices = _mecanicoServices;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = mecanicoServices.GetAll();
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
                var data = mecanicoServices.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Mecanico m)
        {
            try
            {
                var exist = mecanicoServices.Exist(m.Nombre);

                if (exist) return BadRequest("Mecanico ya existe");

                var data = mecanicoServices.Save(m);

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
        public ActionResult update([FromBody] Mecanico m)
        {
            try
            {
                var exist = mecanicoServices.GetById(m.IdMecanico);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = mecanicoServices.Update(m);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
