using SpaceInvadersArmory;

namespace Models
{
    public class Rocinante : Spaceship
    {
        public Rocinante() : base("Rocinante")
        {
            Name = "Rocinante";
            MaxStructure = 3;
            MaxShield = 5;
            CurrentStructure = 3;
            CurrentShield = 5;
            Weapons = new List<Weapon>();
            AddWeapon(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Direct, 2)); 
        }

        public override void AddWeapon(Weapon weapon)
        {
            if (weapon.Type == Weapon.EWeaponType.Direct)
            {
                weapon.ReloadTime = 1;
                base.AddWeapon(weapon);
            }
        } 
    }
}
