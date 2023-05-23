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

    // Not final as this update was made just for testing
    private void Update()
    {
        if (Keyboard.current.digit1Key.isPressed)
        {
            SwitchWeapon(0);
        }

        if (Keyboard.current.digit2Key.isPressed)
        {
            SwitchWeapon(1);
        }

        if (Keyboard.current.digit3Key.isPressed)
        {
            SwitchWeapon(2);
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            m_currentWeapon.Use();
        }
    }

    private void Setup()
    {
        foreach (Weapon weapon in m_weapons)
        {
            weapon.gameObject.SetActive(false);
        }
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
}
