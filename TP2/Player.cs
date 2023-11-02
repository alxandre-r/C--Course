using System.Globalization;

namespace Models
{
    //utlisant l'interface IPlayer
    public class Player : IPlayer
    {
        private string FirstName;
        private string LastName;

        public string Name
        {
            get
            {
                return Format(FirstName) + " " + Format(LastName);
            }
        }

        public string Alias { get; set; }
        
        public Spaceship BattleShip { get; set; }

        //constructeur
        public Player(string FirstName, string LastName, string Alias)
        {
            this.FirstName = Format(FirstName);
            this.LastName = Format(LastName);
            this.Alias = Format(Alias);
            BattleShip = new PlayerSpaceship();
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
        public void ViewShip()
        {
            BattleShip.ViewShip();
        }
        
        //retourne la structure et le shield de son vaisseau
        public string ViewShipEtat()
        {
            return BattleShip.ViewShipEtat();
        }
    }
}
