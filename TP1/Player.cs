using System.Globalization;

namespace Robert_Alexandre_TP1
{
    public class Player
    {
        private string FirstName;
        private string LastName;
        public string Alias { get; set; }
        public string Name;
        public Spaceship PlayerSpaceship { get; set; }

        //constructeur
        public Player(string FirstName, string LastName, string Alias)
        {
            this.FirstName = Format(FirstName);
            this.LastName = Format(LastName);
            this.Alias = Format(Alias);
            Name = Format(FirstName) + " " + Format(LastName);
            //attribution d'un vaisseau par défaut
            PlayerSpaceship = new Spaceship(Alias+"'s");
        }

        //methode permettant une majuscule à chaque début de mot
        public static string Format(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        //méthode d'affichage Alias (Nom Prenom)
        public override string ToString()
        {
            return Alias + " (" + Name + ")";
        }

        //méthode d'affichage du vaisseau du joueur
        public string ViewShip()
        {
            return PlayerSpaceship.ToString();
        }


        /*
        public override bool Equals(object obj)
        {
            if (this.Alias == obj.Alias)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

    }
}
