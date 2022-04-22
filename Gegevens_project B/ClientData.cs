
namespace Gegevens
{
    public class ClientData
    {
        public readonly int ID;

        public readonly string Email = null!;

        public readonly string Naam = null!;

        public readonly string Achternaam = null!;

        public readonly DateTime GeboorteDatum;

        public readonly string TelefoonNummer = null!;

        public readonly string Wachtwoord = null!;

        public ClientData(int id, string email, string naam, string achternaam, DateTime geboortedatum, string telefoonNummer, string wachtwoord)
        {
            ID = id;
            Email = email;
            Naam = naam;
            Achternaam = achternaam;
            GeboorteDatum = geboortedatum;
            TelefoonNummer = telefoonNummer;
            Wachtwoord = wachtwoord;
        }
    }
}
