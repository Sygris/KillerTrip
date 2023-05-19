using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun", order = 1)]
public class GunData : WeaponData
{
    public int MaxAmmo;
    public int MagazineSize;
}
