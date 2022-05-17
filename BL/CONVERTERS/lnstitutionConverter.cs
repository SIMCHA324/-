using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CONVERTERS
{
   public static class lnstitutionConverter
    {
        public static lnstitution convertLnstitutionToDAl(lnstitutionDto lnstitution)
        {
            return new lnstitution
            {
                idInstitution=lnstitution.idInstitution,
                nameInstitution=lnstitution.nameInstitution,
                mail=lnstitution.mail,
                password=lnstitution.password

            };
        }
        public static lnstitutionDto convertLnstitutionToDto(lnstitution lnstitution)
        {
            return new lnstitutionDto
            {
                idInstitution = lnstitution.idInstitution,
                nameInstitution = lnstitution.nameInstitution,
                mail = lnstitution.mail,
                password = lnstitution.password
            };
        }
        internal static lnstitution convertLnstitutionToDAL(lnstitutionDto lnstitution)
        {
            throw new NotImplementedException();
        }

        internal static lnstitutionDto convertLnstitutionToDAl(lnstitution l)
        {
            throw new NotImplementedException();
        }
    }
}
