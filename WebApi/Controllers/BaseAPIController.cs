using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        /*
        internal static readonly  System.Net.Http.Formatting.MediaTypeFormatter DefaultFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter
        {
            UseDataContractJsonSerializer = false,
            SerializerSettings =
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            }
        };

        internal System.Net.Http.HttpResponseMessage ErrorResponse(string message)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.StringContent(message);
            resp.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return resp;
        }

        internal System.Net.Http.HttpResponseMessage ErrorResponse_Ex(Exception ex)
        {
            return ErrorResponse(ex.Message);
        }

        internal System.Net.Http.HttpResponseMessage OkResponse(object result)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.ObjectContent(result.GetType(), result, DefaultFormatter);
            resp.StatusCode = System.Net.HttpStatusCode.OK;
            return resp;
        }

    */

    }
}