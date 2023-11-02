namespace Robert_Alexandre_TP1
{
    public class Spaceship
    {
        public string Owner { get; set; }
        private static int MaxStructure { get; set; }
        private static int MaxShield { get; set; }
        public static int CurrentShield { get; set; }
        public static int CurrentStructure { get; set; }
        private bool IsDestroyed
        {
            get
            {
                if (CurrentStructure == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { }
        }
        public List<Weapon> SpaceshipWeapons { get; set; } 

        //constructeur
        public Spaceship(string owner)
        {
            Owner = owner;
            MaxStructure = 10000;
            CurrentStructure = 10000;
            MaxShield = 5000;
            CurrentShield = 5000;
            IsDestroyed = false;
            //liste d'arme par défaut
            SpaceshipWeapons = new List<Weapon>();
        }

        //méthode d'ajout d'arme (max 3)
        public void addWeaponFromArmory(Weapon weapon)
        {
            //si longueur liste < 3 : ajouter
            if (SpaceshipWeapons.Count < 3)
            {
                SpaceshipWeapons.Add(weapon);
            }
            //sinon erreur
            else
            {
                Console.WriteLine("Vous avez atteint le nombre maximal d'armes (3)");
            }
            
        }
        //méthode de retrait d'arme
        public void RemoveWeapon(Weapon weapon)
        {
            var ajeter = SpaceshipWeapons.Find(weapon => weapon.name == weapon.name);
            SpaceshipWeapons.Remove(ajeter);
        }

        //méthode d'affichage des armes du vaisseau
        public void ViewArmory()
        {
            Console.WriteLine("Voici les armes du vaisseau : \n");
            foreach (Weapon weapon in SpaceshipWeapons)
            {
                Console.WriteLine(weapon.name);
            }
            Console.WriteLine("\n");
        }
        //méthode d'affichage de certaines informations du vaisseau
        public string ViewSpaceshipWeapons()
        {
            string s = "";
            foreach (Weapon weapon in SpaceshipWeapons)
            {
                s = s + weapon.name + " DGT Min" + weapon.MinDamage + " DGT Max" + weapon.MaxDamage + " | ";
            }
            return s;
        }

        //méthode d'affichage des dégâts moyen des armes du vaisseau
        double avgDMG = 0;
        public double AverageDamages()
        {
            foreach (Weapon weaponn in SpaceshipWeapons)
            {
                avgDMG += (weaponn.MinDamage+weaponn.MaxDamage)/2;
            }

            return avgDMG;
        }
        //méthode d'affichage du vaisseau en sa globalité
        public override string ToString()
        {
            return Owner + " SpaceShip :\n" +
                    " Shield : " + CurrentShield / MaxShield * 100 + "% (" + CurrentShield + "/" + MaxShield + ")" +
                    "\n HP : " + CurrentStructure / MaxStructure * 100 + "% (" + CurrentStructure + "/" + MaxStructure + ")" +
                    "\n Armes à bord : " + ViewSpaceshipWeapons() + " DGT moyens : " + AverageDamages();
        }
    }
}
