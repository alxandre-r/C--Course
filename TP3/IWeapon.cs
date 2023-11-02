﻿using System;
using static SpaceInvadersArmory.Weapon;

namespace SpaceInvadersArmory
{
    public interface IWeapon
    {
        string Name { get; set; }
        EWeaponType Type { get; set; }
        double MinDamage { get; set; }
        double MaxDamage { get; set; }
        double AverageDamage { get; }
        double ReloadTime { get; set; }
        double TimeBeforeReload { get; set; }
        bool IsReload { get; }
        double Shoot();
    }
}
