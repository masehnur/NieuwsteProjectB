using Newtonsoft.Json;

namespace Part2

{
   

    public static class ReservationSystem 
    {
        // Pad naar bestand met reserveringen van klanten
        private static readonly string FileName = "./reservations.json";

        public static bool Reserve(int klant_ID, int tafel, int people, DateTime date)
        {
            // Een lege lijst met tuples maken
            List<Reservation> reservations = new();
            if (File.Exists(FileName))
            {
                // Nieuwe stream openen met optie voor lezen van gegevens 
                using StreamReader fileRead = new(FileName);

                // Alle gegevens uit bestand lezen 
                string json = fileRead.ReadToEnd();

                //String gegevens converteren naar een lijst met tupels  
                reservations = JsonConvert.DeserializeObject<List<Reservation>>(json)!;
            }

            // Controleren of de tafel is gereserveerd, zo ja, dan geven we terug dat het onmogelijk is om deze te reserveren
            if (reservations.Any(a => a.TafelID == tafel && a.ReserveringTijd == date)) return false;

            // Gegevens samenvoegen tot één tupel
            Reservation data = new(klant_ID, tafel, people, date);

            // Nieuwe reservering toevoegen aan een lijst met reserveringen
            reservations.Add(data);

            // Nieuwe stream openen met optie voor schrijven van gegevens
            using StreamWriter file = new(FileName);

            // Het bestand wissen en er alle eerder gemaakte reserveringen naartoe schrijven,
            // en de nieuwe, geserialiseerd in json stringand the new one, serialized into json string
            file.Write(JsonConvert.SerializeObject(reservations, Formatting.Indented));
            return true;
        }
    }
}
