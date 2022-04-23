using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : IWeapon
{
    private WeaponData weaponData;
    private GameObject user;
    public void Init(WeaponData _weaponData)
    {
        weaponData = _weaponData;
    }

    public void Using(GameObject _user)
    {
        user = _user;
    }
    
    public void Shoot()
    {
        
    }
}