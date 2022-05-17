using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/user")]
    public class userController : ApiController
    {
        [Route("checkUser")]
        public IHttpActionResult checkUser( string password, string mail)
        {

            
            //userName, password
            //BL.childrenBL.checkUser(mail, password);
            //return ok(user)
            return Ok(true);
        }
    }
}
