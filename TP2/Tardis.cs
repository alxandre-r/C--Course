using SpaceInvadersArmory;

namespace Models
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis() : base("Tardis")
        {
            Name = "Tardis";
            MaxStructure = 15;
            MaxShield = 0;
            CurrentStructure = 15;
            CurrentShield = 0;
            Weapons = new List<Weapon>();
        }
        public override void ShootTarget(Spaceship Spaceship)
        {
            Console.WriteLine("Tardis n'a pas d'arme, il ne peut pas attaquer\n");

        }
        public void Use(List<Spaceship> Spaceship)
        {
            var rnd = new Random();
            var i = rnd.Next(0, Spaceship.Count);
            var j = rnd.Next(0, Spaceship.Count);
            var ship = Spaceship[i];
            Spaceship[i] = Spaceship[j];
            Spaceship[j] = ship;
            Console.WriteLine("Tardis a changer l'ordre des vaisseaux\n");
        }

        // modification de l'affichage du shield de ce vaisseau 
        public override void ViewShip()
        {
            Console.Write(Name + " :\n" +
                    " Shield : Aucun" +
                    "| HP : " + CurrentStructure * 100 / MaxStructure + "% (" + CurrentStructure + "/" + MaxStructure + ")" +
                    "\n Armes à bord : " + ViewSpaceshipWeapons() + " | DGT moyens : " + AverageDamages + "\n\n");
        }

        public override string ViewShipEtat()
        {
            if (IsDestroyed == true)
            {
                return Name + " SpaceShip : détruit !";
            }
            else
            {
                return Name + " SpaceShip :" +
                    " Shield : Aucun (0/0)" +
                    " HP : " + CurrentStructure * 100 / MaxStructure + "% (" + CurrentStructure + "/" + MaxStructure + ")";
            }
        }
    }
}
