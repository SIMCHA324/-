using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CONVERTERS
{
   public static class arrivalTimeConverter
    {
        public static arrivalTime convertArrivalTimeToDal(arrivalTimeDto arrivalTime)
        {
            return new arrivalTime{
                idArrivalTime=arrivalTime.idArrivalTime,
                idChild=arrivalTime.idChild,
                date=arrivalTime.date,
                arrivalTime1=arrivalTime.arrivalTime1
            };
        }
        public static arrivalTimeDto convertArrivalTimeToDTO(arrivalTime arrivalTime)
        {
            return new arrivalTimeDto
            {
                idArrivalTime = arrivalTime.idArrivalTime,
                idChild = arrivalTime.idChild,
                date = arrivalTime.date,
                arrivalTime1 = arrivalTime.arrivalTime1
            };
        }
        internal static arrivalTime convertArrivalTimeToDAL(arrivalTimeDto arrivalTime)
        {
            throw new NotImplementedException();
        }
    }
}
