namespace Robert_Alexandre_TP1
{
    public class Weapon
    {
        public string name;
        public int MinDamage;
        public int MaxDamage;
        public EWeaponType Type { get; set; }


        //constructeur
        public Weapon(string name, int MinDamage, int MaxDamage, EWeaponType type)
        {
            this.name = name;
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            this.Type = type;
        }
        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided
        }

        public override string ToString()
        {
            return name + " DGT Min" + MinDamage + " DGT Max" + MaxDamage;
        }
    }
}
