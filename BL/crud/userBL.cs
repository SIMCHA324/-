using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.crud
{
  public  class userBL
    {
        parentBL ParentBL = new parentBL();
        lnstitutionBL LnstitutionBL = new lnstitutionBL();
        public static userDto checkUser(string mail, string password)
        {
            userDto user = new userDto(null,null);

            parent parent = parentBL.getAllParent().Where(p => p.password == password &&
            p.mail == mail).FirstOrDefault();
            lnstitution lnstitution = lnstitutionBL.getAlllnstitution().Where(l => l.password == password &&
            l.mail == mail).FirstOrDefault();
            if (parent != null)
            {
               user.parent=CONVERTERS.parentConverter.convertParentToDTo( parent);
                return user;
            }
            if(lnstitution != null) 
            {
                user.lnstitution = CONVERTERS.lnstitutionConverter.convertLnstitutionToDto(lnstitution);
                return user;
            }
            return null;
        }  
    }
 }
