using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelButton : MonoBehaviour
{
    [SerializeField] private int _ID;
    public int ID { 
        get { return _ID; }
        set { _ID = value; }
    }

    [SerializeField] private Image _weaponSprite;
    [SerializeField] private TextMeshProUGUI _ammoText;

    public void Setup(Sprite weaponSprite, int ammo, int magazineSize)
    {
        _weaponSprite.sprite = weaponSprite;

        if (ammo == -1)
            _ammoText.text = "";
        else
            _ammoText.text = ammo.ToString() + "/" + magazineSize.ToString();
    }
}
