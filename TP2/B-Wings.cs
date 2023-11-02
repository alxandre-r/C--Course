using SpaceInvadersArmory;

namespace Models
{
    public class B_Wings : Spaceship
    {
        public B_Wings() : base("B-Wings")
        {
            Name = "B-Wings";
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = 30;
            CurrentShield = 0;
            Weapons = new List<Weapon>();
            AddWeapon(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public override void AddWeapon(Weapon weapon)
        {
            if (weapon.Type == Weapon.EWeaponType.Explosive)
            {
                weapon.ReloadTime = 1;
                base.AddWeapon(weapon);
            }
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
