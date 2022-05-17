using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;//כדי שיהיה ניתן להשתמש בנתונים גם אחרי  
using System.Data.Entity.Migrations;


namespace BL.crud
{
   public class childrenBL
    {
        public static void addChildren(childrenDto children)
        {
            using( facialDBEntities db = new facialDBEntities()) { 
               
                db.childrens.Add(CONVERTERS.childrenConverter.convertChildrenToDAl(children));
                db.SaveChanges();
            }
        }
        public static void deleteChildren(childrenDto children)
        {
            using (facialDBEntities db = new facialDBEntities())
            {

                db.childrens.Remove(CONVERTERS.childrenConverter.convertChildrenToDAl(children));
                db.SaveChanges();

            }
        }
        public static List<children> getAllChildren()
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                return db.childrens.Include(v => v.arrivalTimes).ToList();
            }
        }

        public static void updateChildren1(childrenDto children)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                var childrenToUpdate = db.childrens.Find(children.idChild);
                if (childrenToUpdate != null)
                {
                    childrenToUpdate.IdChild = children.idChild;
                    childrenToUpdate.firstName = children.firstName;
                    childrenToUpdate.lastName = children.lastName;
                    childrenToUpdate.idParent1 = children.idParent1;
                    childrenToUpdate.idParent2 = children.idParent2;
                    childrenToUpdate.idInstitution = children.idInstitution;
                    childrenToUpdate.tzChaild = children.tzChaild;
                    childrenToUpdate.image = children.image;
                }
            }

        }
        public static void updateChildren2(childrenDto children)
        {
            using (facialDBEntities db = new facialDBEntities())
            {
                db.childrens.AddOrUpdate(CONVERTERS.childrenConverter.convertChildrenToDAl(children));
                db.SaveChanges();
            }
        }

        public static bool checkChildren(string id)
        {
            List<DAL.children> childrens;
            using (facialDBEntities db = new facialDBEntities())
            {
                childrens = (
                    from c in db.childrens
                    where c.IdChild.Equals(id)
                    select c).ToList();
            }
            if (childrens.Count == 1)
                return true;
            return false;
        }
    }
    }   
