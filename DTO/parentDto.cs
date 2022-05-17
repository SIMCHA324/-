using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class parentDto
    {
        public int idParent { get; set; }
        public string firstNameParent { get; set; }
        public string lastNameParent { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public string password { get; set; }

        //public static implicit operator parentDto(global::DAL.parent v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
