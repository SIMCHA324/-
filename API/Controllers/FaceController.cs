using BL;
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
    [RoutePrefix("api/Face")]
    [EnableCors("*", "*", "*")]

    public class FaceController : ApiController
    {

        [HttpPost, Route("recognize")]
        public IHttpActionResult Recognize([FromBody]Image image, [FromUri]string id)
        {
            Trial trial = new Trial();
            string path = BL.FaceRecognition.ImageService.LoadImage(image);
            trial.ImageProccess( path, id);
            BL.FaceRecognition.ImageService.DeleteImage(path);
            return Ok(true);
        }

       


        [HttpGet , Route("train")]
        public IHttpActionResult Train()
        {
            Trial trial = new Trial();

            if (trial.TrainImagesFromDir())
                trial.ImageProccess( @"D:\המסמכים\Downloads\4.jpg");
            return Ok(true);
        }

        //פונקציה המקבלת תמונות מהלקוח

        [HttpGet, Route("AddPic/{base64}")]
        public IHttpActionResult AddPic(string base64)
        {
            return Ok(true);
        }


    }
}
