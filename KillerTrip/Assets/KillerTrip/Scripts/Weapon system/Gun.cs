using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override bool Use()
    {
        base.Use();
        Debug.Log("\n Coming from the Gun Script!");
        return true;
    }
}
