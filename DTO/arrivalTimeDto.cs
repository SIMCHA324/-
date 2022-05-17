using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class arrivalTimeDto
    {
        public int idArrivalTime { get; set; }
        public int idChild { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan arrivalTime1 { get; set; }

        public arrivalTimeDto( int idChild, DateTime date, TimeSpan arrivalTime1)
        {
            this.idChild = idChild;
            this.date = date;
            this.arrivalTime1 = arrivalTime1;
        }

        public arrivalTimeDto()
        {
        }
    }
}
