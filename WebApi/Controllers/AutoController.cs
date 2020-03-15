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
    public class AutoController : AutoAPIController
    {

        #region Field
        [Dependency]
        public IAutoServices AutoServices { get; set; }
        #endregion

        public AutoController(IAutoServices _baseServices)
        {
            this.AutoServices = _baseServices;
        }


        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = AutoServices.GetAll();
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
                var data = AutoServices.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Auto b)
        {
            try
            {
                var exist = AutoServices.Exist(b.Modelo);

                if (exist) return BadRequest("Base ya existe");

                var data = AutoServices.Save(b);

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
        public ActionResult update([FromBody] Auto b)
        {
            try
            {
                var exist = AutoServices.GetById(b.IdBase);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = AutoServices.Update(b);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
