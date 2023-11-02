namespace SpaceInvadersArmory
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage
        { get { return (MinDamage + MaxDamage) / 2; } }
        public EWeaponType Type { get; set; }
        public enum EWeaponType { Direct, Explosive, Guided }
        public double ReloadTime { get; set; }
        public double TimeBeforeReload { get; set; }

        public bool IsReload
        {
            get
            {
                if (TimeBeforeReload <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //constructeur
        public Weapon(string name, int MinDamage, int MaxDamage, EWeaponType type, double reloadTime = 0)
        {
            Name = name;
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            Type = type;
            ReloadTime = reloadTime;
            TimeBeforeReload = 0;
        }

        public override string ToString()
        {
            return Name + " DGT Min" + MinDamage + " DGT Max" + MaxDamage;
        }

        //shoot
        public double Shoot()
        {
            if (IsReload)
            {

                //type direct
                if (Type == EWeaponType.Direct)
                {
                    //1 chance sur 10 de rater
                    Random rand = new Random();
                    int rate = rand.Next(1, 11);
                    if (rate == 1)
                    {
                        TimeBeforeReload = ReloadTime;
                        return 0;
                    }
                    else
                    {
                        //random dgt entre min et max dmg
                        Random rnd = new Random();
                        int damage = rnd.Next((int)MinDamage, (int)(MaxDamage + 1));
                        TimeBeforeReload = ReloadTime;
                        return damage;
                    }
                }

                //type explosive
                else if (Type == EWeaponType.Explosive)
                {
                    //1 chance sur 4 de rater
                    Random rand = new Random();
                    int rate = rand.Next(1, 5);

                    if (rate == 1)
                    {
                        TimeBeforeReload = ReloadTime;
                        return 0;
                    }
                    else
                    {
                        //random dgt entre min et max dmg
                        Random rnd = new Random();
                        int damage = rnd.Next((int)MinDamage, (int)(MaxDamage + 1));
                        TimeBeforeReload = ReloadTime;
                        return damage;
                    }
                }

                //type guided
                else
                {
                    //dégats min, pas de temps de recharge
                    int damage = (int)MinDamage;
                    TimeBeforeReload = ReloadTime;
                    return damage;
                }
            }
            else
            {
                Console.WriteLine("Il reste " + TimeBeforeReload + " tours avant le prochain tir");
                return 0;
            }
        }
    }
}
