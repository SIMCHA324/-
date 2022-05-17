using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CONVERTERS
{
  public static  class parentConverter
    {
        public static parent convertParentToDAl(parentDto parent)
        {
            return new parent
            {
                idParent = parent.idParent,
                firstNameParent = parent.firstNameParent,
                lastNameParent = parent.lastNameParent,
                tel = parent.tel,
                mail = parent.mail,
                password = parent.password
            };
        }
        public static parentDto convertParentToDTo(parent parent)
        {
            return new parentDto
            {
                idParent = parent.idParent,
                firstNameParent = parent.firstNameParent,
                lastNameParent = parent.lastNameParent,
                tel = parent.tel,
                mail = parent.mail,
                password = parent.password
            };

        }
        internal static parent convertParentToDAL(parentDto parent)
        {
            throw new NotImplementedException();
        }
    }
}
