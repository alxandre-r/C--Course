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
            ListeWeapons = new List<Weapon>();
        }

        //ajout des armes
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

        //affichage plus détailler des armes de l'armurerie
        public void ViewArmoryDetail()
        {
            Console.WriteLine("Voici les armes de l'armurerie : \n");
            foreach (Weapon weapon in ListeWeapons)
            {
                Console.WriteLine(weapon.ToString());
            }
            Console.WriteLine("\n");
        }

        //ajout d'une arme
        public void AjouterArme(Weapon weapon)
        {
            ListeWeapons.Add(weapon);
        }
        
        //affiche les 5 armes ayant les dégats moyens les plus élevés
        public void ViewTop5()
        {
            Console.WriteLine("Voici les 5 armes ayant les dégats moyens les plus élevés : \n");
            var top5 = ListeWeapons.OrderByDescending(x => x.AverageDamage).Take(5);
            foreach (Weapon weapon in top5)
            {
                Console.WriteLine(weapon.Name);
            }
            Console.WriteLine("\n");
        }

        //affiche les 5 armes ayant les dégats minimum les plus haut
        public void ViewTop5Min()
        {
            Console.WriteLine("Voici les 5 armes ayant les dégats minimum les plus haut : \n");
            var top5 = ListeWeapons.OrderByDescending(x => x.MinDamage).Take(5);
            foreach (Weapon weapon in top5)
            {
                Console.WriteLine(weapon.Name);
            }
            Console.WriteLine("\n");
        }
    }
}
