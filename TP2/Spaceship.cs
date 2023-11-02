using SpaceInvadersArmory;
using static System.Net.Mime.MediaTypeNames;

namespace Models
{
    public abstract class Spaceship : ISpaceship
    {
        public string Name { get; set; }
        public double MaxStructure { get; set; }
        public double MaxShield { get; set; }
        public bool IsDestroyed
        {
            get
            {
                if (CurrentStructure <= 0)
                    return true;
                else
                    return false;
            }
            set { }
        }
        public int MaxWeapons { get { return 3; } }

        public List<Weapon> Weapons { get; set; }

        public double AverageDamages
        {
            get
            {
                double average = 0;
                foreach (Weapon weapon in Weapons)
                {
                    average += weapon.AverageDamage;
                }
                return average;
            }
        }
        public double CurrentShield { get; set; }
        public double CurrentStructure { get; set; }

        public bool BelongsPlayer { get; set; }

        //constructeur
        public Spaceship(string Name)
        {
            this.Name = Name;
            MaxStructure = 10;
            CurrentStructure = 10;
            MaxShield = 10;
            CurrentShield = 10;
            IsDestroyed = false;
            //liste d'arme par défaut
            Weapons = new List<Weapon>();
        }

        //---------------METHODES-----------------//
        
        public void TakeDamages(double damage)
        {
            //si  shield est plus grand que les dégats, enlever que du shield
            if (CurrentShield - damage >= 0)
            {
                CurrentShield -= damage;
            }
            //sinon si le shield est actif
            else if (CurrentShield > 0)
            {
                damage -= CurrentShield;        //on soustrait le shield des damages...
                CurrentShield = 0;
                CurrentStructure -= damage;     //...pour l'appliquer le reste sur la structure
            }
            //sinon structure moins dégâts, et si dégâts plus grand que structure, structure = 0;
            else
            {
                CurrentStructure = CurrentStructure >= damage ? CurrentStructure - damage : 0;
            }
        }


        public void RepairShield(double repair)
        {
            //si le shield est plus petit que le max
            if (CurrentShield + repair <= MaxShield)
            {
                CurrentShield += repair;
            }
            //sinon si le shield est plus grand que le max
            else
            {
                CurrentShield = MaxShield;
            }
        }


        //méthode de tir sur (une cible)
        public virtual void ShootTarget(Spaceship target)
        {
            //réduit le temps de chargement de 1
            ReloadWeapons();

            if (Weapons.Count > 0)
            {
                //choix aleatoire d'une arme chargée du vaisseau
                Random rnd = new Random();
                int numArme = rnd.Next(0, Weapons.Count);
                Weapon arme = Weapons[numArme];

                while (arme.TimeBeforeReload > 0)
                {
                    numArme = rnd.Next(0, Weapons.Count);
                    arme = Weapons[numArme];
                }
                
                //la cible prend les dégats de l'arme choisie
                double dgt = arme.Shoot();
                target.TakeDamages(dgt);
                
                //si dgt = 0
                if (dgt == 0)
                {
                    Console.WriteLine($"{Name} tire avec {arme.Name} : tir raté");
                }
                else
                {
                    Console.WriteLine($"{Name} tire avec {arme.Name} : {dgt} de dégats infligés");
                }
            }
            else
            {
                Console.WriteLine($"{Name} n'a pas d'arme à bord");
            }
        }

        public void ReloadWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.TimeBeforeReload --;
            }
        }



        //méthode d'ajout d'arme (max 3)
        public virtual void AddWeapon(Weapon weapon)
        {
            //si longueur liste < 3 : ajouter
            if (Weapons.Count < 3)
            {
                Weapons.Add(weapon);
            }
            //sinon erreur
            else
            {
                Console.WriteLine("Vous avez atteint le nombre maximal d'armes (3)");
            }
            
        }
        //méthode de retrait d'arme à l'aide de son nom
        public void RemoveWeapon(Weapon weapon)
        {
            var ajeter = Weapons.Find(weapon => weapon.Name == weapon.Name);
            Weapons.Remove(ajeter);
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
        }


        //méthode d'affichage des armes du vaisseau
        public void ViewWeapons()
        {
            Console.WriteLine("Voici les armes du vaisseau : \n");
            foreach (Weapon weapon in Weapons)
            {
                Console.WriteLine(weapon.Name);
            }
        }
        
        //méthode d'affichage de certaines informations du vaisseau
        public string ViewSpaceshipWeapons()
        {
            //si nombre d'arme > 0
            if (Weapons.Count > 0)
            {
                string result = "";
                foreach (Weapon weapon in Weapons)
                {
                    result += weapon.Name + " ";
                }
                return result;
            }
            else
            {
                return "Aucune";
            }
        }

        //méthode d'affichage du vaisseau en sa globalité
        public virtual void ViewShip()
        {
            Console.Write( Name + " :\n" +
                    " Shield : " + CurrentShield * 100 / MaxShield + "% (" + CurrentShield + "/" + MaxShield + ")" +
                    "| HP : " + CurrentStructure * 100/ MaxStructure + "% (" + CurrentStructure + "/" + MaxStructure + ")" +
                    "\n Armes à bord : " + ViewSpaceshipWeapons() + " | DGT moyens : " + AverageDamages + "\n\n");
        }
        //méthode d'affichage de létat du vaisseau
        public virtual string ViewShipEtat()
        {
            if (IsDestroyed == true)
            {
                return Name + " SpaceShip : détruit !";
            }
            else
            {
                return Name + " SpaceShip :" +
                    " Shield : " + CurrentShield * 100 / MaxShield + "% (" + CurrentShield + "/" + MaxShield + ") " +
                    " HP : " + CurrentStructure * 100 / MaxStructure + "% (" + CurrentStructure + "/" + MaxStructure + ")";
            }
        }
    }
}
