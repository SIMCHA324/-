using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/children")]
    public class childrensController : ApiController
    {
        [Route("GetNumChildren")]
        [HttpGet]
        public IHttpActionResult GetNumChildren()
        {
            return Ok(1);
        }
        [Route("GetNumChildrenByIdChild/{idChild}")]
        [HttpGet]
        public IHttpActionResult GetNumChildrenByIdChild(int areaId)
        {
            return BadRequest();
            
        }
        [Route("AddChildren"), HttpPost]
        public IHttpActionResult AddChildren(childrenDto childrens)
        {
            BL.crud.childrenBL.addChildren(childrens);
            return Ok(true);
        }
    }
}
