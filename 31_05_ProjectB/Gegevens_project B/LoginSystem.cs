using Newtonsoft.Json;

namespace Gegevens
{
    public static class LoginSystem
    {
        // Geregistreerde klantgegevens, als het nul is, is de klant uitgelogd
        public static ClientData? Data { get; set; }

        // Pad naar bestand met klantenaccounts
        private static readonly string FileName = "./clientdata.json";

        public static void Logout() => Data = null;

        // Als de gegevens niet nul zijn, betekent dit dat de klant is ingelogd
        public static bool IsLogged() => Data != null;
        
        public static bool Register(string email, string naam, string achterNaam, DateTime geboortedatum, string telefoonnummer,
            string password)
        {
            // Een lege lijst met tuples maken
            List<ClientData> users = new();
            if (File.Exists(FileName))
            {
                // Nieuwe stream openen met optie voor lezen van gegevens
                using StreamReader fileRead = new(FileName);

                // Alle gegevens uit bestand lezen
                string json = fileRead.ReadToEnd();

                // Stringgegevens converteren naar een lijst met tupels
                users = JsonConvert.DeserializeObject<List<ClientData>>(json)!;
            }

            // Controleren of een van de accounts op de lijst hetzelfde e-mailadres heeft, zo ja, dan retourneren we dat de registratie is mislukt
            if (users.Any(a => a.Email == email)) return false;

            // Gegevens samenvoegen tot één tupel
            ClientData data = new(users.Count, email, naam, achterNaam,  geboortedatum, telefoonnummer, password);

            // Nieuwe klantgegevens toevoegen aan de lijst met accounts
            users.Add(data);

            // Nieuwe stream openen met optie voor schrijven van gegevens
            using StreamWriter file = new(FileName);
            JsonSerializerSettings settings = new() { DateFormatString = "yyyy-MM-dd" };

            //Bestand wissen en schrijven naar bestand alle eerder geregistreerde accounts en de nieuwe, geserialiseerd in json-tekenreeks 
            file.Write(JsonConvert.SerializeObject(users, Formatting.Indented, settings));

            //Gegevens toewijzen aan openbare tuple met klantgegevens
            Data = data;
            return true;
        }

        public static bool Login(string email, string password)
        {
            // Als het bestand met de accounts van klanten niet bestaat, kunnen we die aanmelding als mislukt retourneren
            if (!File.Exists(FileName)) return false;

            // Nieuwe stream openen met optie voor lezen van gegevens
            using StreamReader fileRead = new(FileName);

            // Alle gegevens van bestand naar string lezen
            string json = fileRead.ReadToEnd();

            // Stringgegevens converteren naar een lijst met tupels
            var users = JsonConvert.DeserializeObject<List<ClientData>>(json)!;

            // Zoeken of een account met hetzelfde e-mailadres en wachtwoord, zo nee, variabele gebruiker wordt ingesteld op null
            var user = users.Find(a => a.Email == email && a.Wachtwoord == password);

            //als variabele gebruiker null is, kunnen we retourneren dat het inloggen is mislukt
            if (user == null) return false;

            // Gegevens toewijzen aan openbare tuple met klantgegevens
            Data = user;
            return true;
        }
    }
}
