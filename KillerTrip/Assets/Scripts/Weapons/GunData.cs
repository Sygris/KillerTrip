using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string Name;

    [Header("Shooting")]
    public float Damage;
    public float MaxDistance;

    [Header("Reloading")]
    public int CurrentAmmo;
    public int MagSize;
    public float FireRate;
    public float ReloadTime;
    [HideInInspector]
    public bool IsReloading;
}
