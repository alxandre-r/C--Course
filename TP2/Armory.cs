using Models;
using SpaceInvadersArmory;
using System.Numerics;
using System;

namespace SpaceInvadersArmory
{
    public class Armory
    {
        public List<Weapon> ListeWeapons;
        //constructeur
        public Armory()
        {
            Init();
        }


        //ajout de 3 armes
        public void Init()
        {
            ListeWeapons = new List<Weapon>
            {
                new Weapon("Lasers", 2, 3, Weapon.EWeaponType.Guided, 2),
                new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5),
                new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2),
                new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1),
                new Weapon("EMG", 1, 7, Weapon.EWeaponType.Direct, 1.5),
                new Weapon("Missile", 4, 100, Weapon.EWeaponType.Direct, 4)
            };
        }
        
        //affichage d'armory
        public void ViewArmory()
        {
            Console.WriteLine("Voici les armes de l'armurerie : \n");
            foreach (Weapon weapon in ListeWeapons)
            {
                Console.WriteLine(weapon.Name);
            }
            Console.WriteLine("\n");
        }
    }
}
