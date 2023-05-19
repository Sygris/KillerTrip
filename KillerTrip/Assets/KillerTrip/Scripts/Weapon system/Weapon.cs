using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public override bool Use()
    {
        Debug.Log("Using weapon:" + " " + gameObject.name);
        return true;
    }
}
