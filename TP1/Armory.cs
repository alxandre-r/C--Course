namespace Robert_Alexandre_TP1
{
    public class Armory
    {
        public List<Weapon> ListeWeapons;
        //constructeur
        public Armory()
        {
            Init();
        }


        //ajout des 3 armes
        public void Init()
        {
            ListeWeapons = new List<Weapon>
            {
                new Weapon("Mitrailleuses", 350, 1000, Weapon.EWeaponType.Direct),
                new Weapon("Missiles", 1500, 4000, Weapon.EWeaponType.Explosive),
                new Weapon("Lasers", 750, 2000, Weapon.EWeaponType.Guided)
            };
        }
        //méthode d'affichage d'armory
        public void ViewArmory()
        {
            Console.WriteLine("Voici les armes de l'armurerie : \n");
            foreach (Weapon weapon in ListeWeapons)
            {
                Console.WriteLine(weapon.name);
            }
            Console.WriteLine("\n");

        }

    }
}
