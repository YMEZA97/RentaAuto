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
    
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class BaseController : BaseAPIController
    {

        #region Field
        [Dependency]
        public IBaseServices baseServices { get; set; }
        #endregion

        public BaseController(IBaseServices _baseServices)
        {
            this.baseServices = _baseServices;
        }

        
        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = baseServices.GetAll();
                return  Ok(data);
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
                var data = baseServices.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Base b)
        {
            try
            {
                var exist = baseServices.Exist(b.Nombre);

                if (exist) return BadRequest("Base ya existe");

                var data = baseServices.Save(b);

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
        public ActionResult update([FromBody] Base b)
        {
            try
            {
                var exist = baseServices.GetById(b.IdBase);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = baseServices.Update(b);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }


    }
}
