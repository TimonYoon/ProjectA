using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType
{
    NORMAL,
    SHOTGUN,
}

[CreateAssetMenu(fileName = "Weapon Data",menuName = "Scriptebel Object/Weapon Data",order = int.MaxValue)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private EWeaponType weaponType;
    public EWeaponType WeaponType => weaponType;
    [SerializeField] private string weaponName;
    public string WeaponName => weaponName;

}
