using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BL.crud
{
    public class arrivalTimeBL
    {
        //פונקציה המעדכנת כל ילד שמגיע לגן
        public static bool updateChildArrival(int idChild)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                db.arrivalTimes.Add(CONVERTERS.arrivalTimeConverter.convertArrivalTimeToDAL(
                    new DTO.arrivalTimeDto(idChild, DateTime.Now.Date, DateTime.Now.TimeOfDay)));
                return true;
            }
            return false;
        }
        // פונקציה המחזירה את הילדים שהגיעו לגן.
        public static List<arrivalTime> getArrivalChildren()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                List<arrivalTime> childenInTheSchool = db.arrivalTimes.Where(a => a.date.Year == DateTime.Now.Year &&
                a.date.Month == DateTime.Now.Month && a.date.Day == DateTime.Now.Day).ToList();
                    //Where(c =>Convert.ToDateTime(c.arrivalTime1).Equals( DateTime.Now.Hour)).ToList();
                return childenInTheSchool;


            }
            return null;
        }

        // פונקצייה המחזירה את הילדים שעוד לא הגיעו

        public static List<children> getChildrenNotArrival()
        {

            //    //שליפת כל הילדים
            //    //להוריד מהרשימה את כל הילדים שהגיעו
            //    //להחזיר את הרשימה של שאר הילדים

            List<children> AllChildren = childrenBL.getAllChildren();
            List<arrivalTime> Arived = getArrivalChildren().FindAll(
                a => a.date.Year == DateTime.Now.Year &&//להשלים
                DateTime.Now.Hour >= 9

            );
            List<children> DontArrive = new List<children>();
            foreach (children item in AllChildren)
            {
                if (Arived.Find(a => a.idChild == item.IdChild) == null)
                {
                    DontArrive.Add(item);
                }
            }
            //  return DontArrive;
            List<parent> Parents = new List<parent>();
            foreach (children item in DontArrive)
            {
                Parents.Add(parentBL.getAllParent().Find(a => a.idParent == item.idParent1));
            }
            //לשלוח כל הורה ברשימה לפונקציית שליחת מייל 
            //לעבור ב forecht על כל הParent ולשלוח לכל הורה שהילד שלו לא נמצא הודעה.
            foreach (parent item in Parents)
            {
                sendMailToParent(item);
            }
            return null;
        }


        //פונקציית שליחת מייל
        public static void sendMailToParent(parent parent)
        {
            string email = "mugbagnim@gmail.com";
            string password = "324010446";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(email);
                mail.To.Add(parent.mail);
                mail.Subject = "מוגנים בגנים";
                mail.Body = "<h1>בקר טוב הורה יקר</h1>";
                mail.IsBodyHtml = true;
                // mail.Attachments.Add(new Attachment("C:\\file.zip"));
                try
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(email, password);
                        smtp.EnableSsl = true;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Send(mail);

                    }
                }
                catch (Exception ex)
                {

                }

                //var loginInfo = new NetworkCredential(email, password);
                //var msg = new MailMessage();
                //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //msg.From = new MailAddress(email);
                //msg.To.Add(new MailAddress("simchonetifergan@gmail.com"));
                //msg.Subject = "קישור לאפליקציית ילד בגן " + parent.idParent;

                //string htmlBodyString = "hello world";

                //#region buildHtmlMessageBody

                //#endregion
                //AlternateView alternateView = AlternateView.
                //CreateAlternateViewFromString(htmlBodyString, null,
                //MediaTypeNames.Text.Html);
                //msg.AlternateViews.Add(alternateView);
                //msg.IsBodyHtml = true;
                //smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
                //smtpClient.Send(msg);
            }
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        
        }

    }
}




