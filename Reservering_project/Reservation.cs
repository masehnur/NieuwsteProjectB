using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Part2

{
    public class Reservation
    {
        public readonly int KlantID;

        public readonly int TafelID;

        public readonly int AantalPersonen;

        public readonly DateTime ReserveringTijd;

        public Reservation(int klantID, int tafelID, int aantalPersonen, DateTime reserveringTijd)
        {
            KlantID = klantID;
            TafelID = tafelID;
            AantalPersonen = aantalPersonen;
            ReserveringTijd = reserveringTijd;
        }
    }
}
