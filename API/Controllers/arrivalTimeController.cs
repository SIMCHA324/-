using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL.crud;



 
namespace API.Controllers
{
    [RoutePrefix("api/Arrival")]
    [EnableCors("*", "*", "*")]
    public class arrivalTimeController : ApiController
    {
        [HttpGet, Route("getChildrenNotArrival")]
        public IHttpActionResult SendMail()
        {
            arrivalTimeBL.getChildrenNotArrival();
            return Ok();
        }
    }
}
