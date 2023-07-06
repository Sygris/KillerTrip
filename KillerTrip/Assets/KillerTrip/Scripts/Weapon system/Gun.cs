using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private ParticleSystem _muzzleEffect;

    private int _currentAmmo;
    private int _ammoAvailable;

    private bool _canShootNextBullet;

    #region Properties
    public int CurrentAmmo
    {
        get { return _currentAmmo; }
    }

    public int AmmoAvailable
    {
        get { return _ammoAvailable; }
    }
    #endregion

    private void Start()
    {
        _canShootNextBullet = true;

        _currentAmmo = ((GunData)ItemData).MagazineSize;
        _ammoAvailable = ((GunData)ItemData).MaxAmmo;
    }

    public override bool Use()
    {
        if (CanShoot())
        {
            _muzzleEffect.Emit(1);
            _currentAmmo--;
        }
        else
        {
            Debug.Log("Reload u dumbass!");
        }
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

    protected IEnumerator FireRateDelay()
    {
        _canShootNextBullet = false;

        yield return new WaitForSeconds(((GunData)ItemData).FireRate);
    }

    private bool CanShoot()
    {
        return _currentAmmo > 0 && _canShootNextBullet;
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
