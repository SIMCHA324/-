using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.Entity;//כדי שיהיה ניתן להשתמש בנתונים גם אחרי  
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace BL.crud
{
    public class parentBL
    {
        public static void addParent(parentDto parent)
        {
            using(facialDBEntities db = new facialDBEntities())
            {
                db.parents.Add(CONVERTERS.parentConverter.convertParentToDAl(parent));
                db.SaveChanges();
            }
        }
        public static void deleteParent(parentDto parent)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                db.parents.Remove(CONVERTERS.parentConverter.convertParentToDAl(parent));
                db.SaveChanges();
            }
        }
        public static List<parent> getAllParent()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                return db.parents.Include(p => p.childrens).Include(p => p.childrens1).ToList();
            }
        }
        public static void updateparent(parentDto parent)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                var parentToUpdate = db.parents.Find(parent.idParent);
                if (parentToUpdate != null)
                {
                    parentToUpdate.idParent = parent.idParent;
                    parentToUpdate.firstNameParent = parent.firstNameParent;
                    parentToUpdate.lastNameParent = parent.lastNameParent;
                    parentToUpdate.tel = parent.tel;
                    parentToUpdate.mail = parent.mail;
                    parentToUpdate.password = parent.password;
                }
            }
        }

        //public static parent getParentById(int idParent)
        //{
        //    return
        //}

        public static List<parent> getParent()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                return db.parents.ToList();
            }
        }

      

    }
}
