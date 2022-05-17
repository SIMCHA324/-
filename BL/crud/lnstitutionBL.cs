using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.Entity;//כדי שיהיה ניתן להשתמש בנתונים גם אחרי  
using System.Data.Entity.Migrations;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace BL.crud
{
    public class lnstitutionBL
    {
        public static void addlnstitution(lnstitutionDto lnstitution)
        {
            using (facialDBEntities db = new facialDBEntities())
            {

                db.lnstitutions.Add(CONVERTERS.lnstitutionConverter.convertLnstitutionToDAl(lnstitution));
                db.SaveChanges();
            }
        }
        public static void sendMailToParent(parent parent)
        {
            try
            {
                string email = "s0583231105@gmail.com";
                string password = "SIMCHA324";
                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress("simchonetifergan@gmail.com"));
                msg.Subject = "קישור לאפליקציית ילד בגן " + parent.idParent;

                string htmlBodyString = "hello world";

                #region buildHtmlMessageBody

                #endregion
                AlternateView alternateView = AlternateView.
                CreateAlternateViewFromString(htmlBodyString, null, MediaTypeNames.Text.Html);
                msg.AlternateViews.Add(alternateView);
                msg.IsBodyHtml = true;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void deletelnstitution(lnstitutionDto lnstitution)
        {
            using (facialDBEntities db = new facialDBEntities())
            {

                db.lnstitutions.Remove(CONVERTERS.lnstitutionConverter.convertLnstitutionToDAl(lnstitution));
                db.SaveChanges();

            }
        }
        public static List<lnstitution> getAlllnstitution()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                return db.lnstitutions.Include(l => l.childrens).ToList();
            }
        }
        public static void updatelnstitution1(lnstitutionDto lnstitution)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                var lnstitutionToUpdate = db.lnstitutions.Find(lnstitution.idInstitution);
                if (lnstitutionToUpdate != null)
                {
                    lnstitutionToUpdate.idInstitution = lnstitution.idInstitution;
                    lnstitutionToUpdate.nameInstitution = lnstitution.nameInstitution;
                    lnstitutionToUpdate.mail = lnstitution.mail;
                    lnstitutionToUpdate.password = lnstitution.password;
                }
            }

        }
        public static void updatelnstitution2(lnstitutionDto lnstitution)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                db.lnstitutions.AddOrUpdate(CONVERTERS.lnstitutionConverter.convertLnstitutionToDAl(lnstitution));
                db.SaveChanges();
            }
        }


        public static lnstitutionDto checkUser(string mail, string password)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                List<lnstitution> lnList = db.lnstitutions.ToList();
                List<lnstitutionDto> lnstitutionDtos = new List<lnstitutionDto>();
                lnList.ForEach(l =>
                {
                    lnstitutionDto lDto = CONVERTERS.lnstitutionConverter.convertLnstitutionToDAl(l);
                    lnstitutionDtos.Add(lDto);

                });
                lnstitutionDto mylnstitution = lnstitutionDtos.Find(p => p.mail == mail && p.password == password);
                return mylnstitution;
            }
        }
        public static List<lnstitution> getLnstitution()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                return db.lnstitutions.ToList();
            }
        }

    }
}

