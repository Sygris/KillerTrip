using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private ParticleSystem _muzzleEffect;

    private int _currentAmmo;
    public int CurrentAmmo
    {
        get { return _currentAmmo; }
    }

    private int _ammoAvailable;
    public int AmmoAvailable
    {
        get { return _ammoAvailable; }
    }

    private void Start()
    {
        _currentAmmo = ((GunData)ItemData).MagazineSize;
        _ammoAvailable = ((GunData)ItemData).MaxAmmo;
    }

    public override bool Use()
    {
        _muzzleEffect.Emit(1);
        _currentAmmo--;
        return true;
    }

    private void Reload()
    {
        // If the player still has ammo and its not trying to reload with a full magazine
        if (_currentAmmo < ((GunData)ItemData).MagazineSize && _ammoAvailable > 0)
        {
            // How many bullets are missing to fill the magazine
            int bulletsNeeded = ((GunData)ItemData).MagazineSize - _currentAmmo;

            // Assigns bulletsToAdd with the min value between bulletsNeeded and _ammoAvailable
            // In this case, if the player has less ammo available than what is needed to refill the entire magazine
            // it only reloads with the ammo available
            int bulletsToAdd = Mathf.Min(bulletsNeeded, _ammoAvailable);

            _ammoAvailable -= bulletsToAdd;
            _currentAmmo += bulletsToAdd;
        }
    }

    private void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.Reloading += Reload;
    }

    private void OnDisable()
    {
        StarterAssets.StarterAssetsInputs.Reloading -= Reload;
    }
}
