using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private ParticleSystem _muzzleEffect;

    private GunData _data;
    private int _currentAmmo;
    public int CurrentAmmo
    {
        get { return _currentAmmo; }
    }

    private void Start()
    {
        _currentAmmo = ((GunData)ItemData).MagazineSize;
        //if (ItemData is GunData)
        //{
        //    _data = (GunData)ItemData;
        //}

        //_currentAmmo = _data.MagazineSize;
    }

    public override bool Use()
    {
        _muzzleEffect.Emit(1);
        _currentAmmo--;
        return true;
    }
}
