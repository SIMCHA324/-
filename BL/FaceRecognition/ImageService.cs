using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.FaceRecognition
{
  public  class ImageService
    {
        //  קבלת התמונה מהלקוח ושמירה זמנית  בתיקיה לפני זיהוי
        public static string LoadImage(DTO.Image img)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(img.base64);
            string path = HttpContext.Current.Server.MapPath("~") + @"\TempImages\";
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);

                path += DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg"; 
                image.Save(path);
 
            }

            return path; 
        }

        public static bool DeleteImage(string path)
        {
            File.Delete(path);
            return true;
        }
    }
}
