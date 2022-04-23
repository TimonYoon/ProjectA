using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot();
}

public class Weapon : IWeapon
{
    private WeaponData weaponData;

    public void Init(WeaponData _weaponData)
    {
        weaponData = _weaponData;
    }
    public void Shoot()
    {
        
    }
}
