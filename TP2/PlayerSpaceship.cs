using SpaceInvadersArmory;

namespace Models
{
    public class PlayerSpaceship : Spaceship
    {
        public PlayerSpaceship() : base("Your spaceship")
        {
            Name = "Your spaceship";
            MaxStructure = 50;
            MaxShield = 20;
            CurrentStructure = 50;
            CurrentShield = 20;
            Weapons = new List<Weapon>();
            AddWeapon(new Weapon("Laser", 2, 3, Weapon.EWeaponType.Direct, 2));
            AddWeapon(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Direct, 4));
            AddWeapon(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Direct, 1.5));
        }


        public override void AddWeapon(Weapon weapon)
        {
            //si l'arme est de type direct
            if (weapon.Type == Weapon.EWeaponType.Direct)
            {
                weapon.ReloadTime = 1;
                base.AddWeapon(weapon);
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            //réduit le temps de chargement de 1
            ReloadWeapons();

            //si vaisseau possède des armes
            if (Weapons.Count > 0)
            {

                //choix de l'arme à l'aide de son index
                Console.WriteLine("Choisissez l'arme à utiliser : ");
                for (int i = 0; i < Weapons.Count; i++)
                {
                    //si rechargé 
                    if (Weapons[i].TimeBeforeReload <= 0)
                    {
                        Console.WriteLine(i + " : " + Weapons[i].Name + " (chargée)");
                    }
                    //sinon affiche combien de tours restants
                    else
                    {
                        Console.WriteLine(i + " : " + Weapons[i].Name + " (" + Weapons[i].TimeBeforeReload + " tours de recharge restants)");
                    }
                }

                string choix = Console.ReadLine();

                //si choix valide
                if (int.TryParse(choix, out int choixInt) && choixInt >= 0 && choixInt < Weapons.Count)
                {
                    var arme = Weapons[choixInt];
                    //la cible prend les dégats de l'arme choisie
                    double dgt = arme.Shoot();
                    target.TakeDamages((int)dgt);

                    if (target.IsDestroyed)
                    {
                        Console.WriteLine("Le vaisseau " + target.Name + " a subi " + dgt + " points de dégâts et est détruit");
                    }
                    else if (dgt > 0)
                    {
                        Console.WriteLine("Le vaisseau " + target.Name + " a subi " + dgt + " points de dégâts !");
                        Console.WriteLine("Il lui reste " + target.CurrentStructure + " points de structure et " + target.CurrentShield + " points de bouclier.");
                    }
                }
                //si choix non valide
                else
                {
                    Console.WriteLine("Choix non valide, réessayez");
                    ShootTarget(target);
                }
            }
            else
            {
                Console.WriteLine("Veuillez ajouter une arme au vaisseau");
            }
        }
    }
}
