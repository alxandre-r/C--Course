using SpaceInvadersArmory;

namespace Models
{
    public class Dart : Spaceship
    {
        public Dart() : base("Dart")
        {
            Name = "Dart";
            MaxStructure = 10;
            MaxShield = 3;
            CurrentStructure = 10;
            CurrentShield = 3;
            Weapons = new List<Weapon>();
            AddWeapon(new Weapon("Laser", 2, 3, Weapon.EWeaponType.Direct, 2));

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
    }
}
