using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class childrenDto
    {
        public int idChild { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string @class { get; set; }
        public int idParent1 { get; set; }
        public int idParent2 { get; set; }
        public int idInstitution { get; set; }
        public string tzChaild { get; set; }
        public string image { get; set; }
    }
}