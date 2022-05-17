using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class userDto
    {
        public parentDto parent { get; set; }
        public lnstitutionDto lnstitution { get; set; }

        public userDto(parentDto parent, lnstitutionDto lnstitution)
        {
            this.parent = parent;
            this.lnstitution = lnstitution;
        }
    }
}
