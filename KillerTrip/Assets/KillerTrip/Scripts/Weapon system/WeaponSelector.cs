using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private List<Weapon> m_weapons = new List<Weapon>();

    private int m_index;
    private Weapon m_currentWeapon;

    public Weapon CurrentWeapon => m_currentWeapon;

    private void Start()
    {
        m_index = 0;
        m_currentWeapon = m_weapons[m_index];

        Setup();
        SwitchWeapon(m_index);
    }

    private void Setup()
    {
        foreach (Weapon weapon in m_weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    private void Use()
    {
        m_currentWeapon.Use();
    }

    public void SwitchWeapon(int index)
    {
        if (m_index >= m_weapons.Count)
        {
            Debug.LogError("You are trying to assign the current weapon to an Non-Existing Weapon, you dumb dumb!");
            return;
        }

        m_index = index;

        for (int i = 0; i < m_weapons.Count; i++)
        {
            if (m_weapons[i] == null)
            {
                break;
            }

            if (i != m_index)
            {
                // Disable weapon 
                m_weapons[i].gameObject.SetActive(false);
            }
            else
            {
                // Enable weapon
                m_weapons[i].gameObject.SetActive(true);
                m_currentWeapon = m_weapons[i];
            }
        }
    }

    public void GetWeaponData(int index, out Sprite sprite, out int ammo, out int maxAmmo)
    {
        sprite = m_weapons[index].ItemData.Sprite;

        if (m_weapons[index] is Gun)
        {
            ammo = m_weapons[index].GetComponent<Gun>().CurrentAmmo;
            maxAmmo = ((Gun)m_weapons[index]).AmmoAvailable;
        }
        else
        {
            ammo = 0;
            maxAmmo = 0;
        }
    }

    private void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.Attacking += Use;
    }

    private void OnDisable()
    {
        StarterAssets.StarterAssetsInputs.Attacking -= Use;
    }
}
