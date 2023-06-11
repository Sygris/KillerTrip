using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private ParticleSystem _muzzleEffect;

    public override bool Use()
    {
        _muzzleEffect.Emit(1);
        return true;
    }
}
