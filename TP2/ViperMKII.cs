using SpaceInvadersArmory;

namespace Models
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII() : base("ViperMKII")
        {
            Name = "ViperMKII";
            MaxStructure = 10;
            MaxShield = 15;
            CurrentStructure = 10;
            CurrentShield = 15;
            Weapons = new List<Weapon>();
            AddWeapon(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            AddWeapon(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Direct, 1.5));
            AddWeapon(new Weapon("Missile", 4, 10, Weapon.EWeaponType.Direct, 4));
        }
    }
}
