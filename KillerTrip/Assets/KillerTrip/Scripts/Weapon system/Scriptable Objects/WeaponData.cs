using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon", order = 0)]
public class WeaponData : ItemData
{
    public int Damage;
    public float FireRate;
}
