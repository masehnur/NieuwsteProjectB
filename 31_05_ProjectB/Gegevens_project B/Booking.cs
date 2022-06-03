using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gegevens
{
    internal class Booking
    {
        //class eigenschappen
        public int TableNo;
        public DateTime BookingDateTime;
        public string BookingName;
        public string aantalpersonen;


        public Booking(int tableNo, DateTime dateTime)
        {
            this.TableNo = tableNo;
            this.BookingDateTime = dateTime;
        }
    }
}
