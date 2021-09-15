using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgencia
{
    public class Rental
    {
        public int Id { get; set; }
        public int RentalDuration { get; set; }
        public int RentalClientId { get; set; }
        public int RentalCarId { get; set; }
        public string RentalReturnDate { get; set; }
    }
}
