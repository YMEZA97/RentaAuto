using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Unity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class OrdenController : OrdenAPIController
    {


        #region Field
        [Dependency]
        public IOrdenServices OrdenServices { get; set; }
        #endregion

        public OrdenController(IOrdenServices _baseServices)
        {
            this.OrdenServices = _baseServices;
        }


        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = OrdenServices.GetAll();
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
                var data = OrdenServices.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Orden b)
        {
            try
            {
                var exist = OrdenServices.Exist(b.IdOrden) ;

                if (exist) return BadRequest("Base ya existe");

                var data = OrdenServices.Save(b);

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
        public ActionResult update([FromBody] Orden b)
        {
            try
            {
                var exist = OrdenServices.GetById(b.IdOrden);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = OrdenServices.Update(b);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
