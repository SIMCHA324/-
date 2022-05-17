using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CONVERTERS
{
   public static  class childrenConverter
    {
        public static  children convertChildrenToDAl(childrenDto children)
        {
            return new children
            {
                IdChild = children.idChild,
                firstName = children.firstName,
                lastName = children.lastName,
                idParent1 = children.idParent1,
                idParent2 = children.idParent2,
                idInstitution = children.idInstitution,
                tzChaild = children.tzChaild,
                image = children.image


            };
        }
        public static childrenDto convertChildrenToDTO(children children)
        {
            return new childrenDto
            {
                idChild = children.IdChild,
                firstName = children.firstName,
                lastName = children.lastName,
                idParent1 = children.idParent1,
                idParent2 = children.idParent2,
                idInstitution = children.idInstitution,
                tzChaild = children.tzChaild,
                image = children.image


            };
        }
        internal static children convertChildrenToDAL(childrenDto children)
        {
            throw new NotImplementedException();
        }
    } 
}
