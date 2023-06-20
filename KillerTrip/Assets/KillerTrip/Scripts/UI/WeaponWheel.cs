using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    [SerializeField] private GameObject m_weaponWheelVisuals;
    [SerializeField] private WeaponSelector m_weaponSelector;
    private bool m_isWeaponWheelActive = false;

    struct WeaponData
    {
        public Sprite Sprite;
        public int Ammo, MaxAmmo;
    }

    private void Start()
    {
        m_weaponWheelVisuals.SetActive(false);
    }

    private void ToggleWeaponWheel()
    {
        m_isWeaponWheelActive = !m_isWeaponWheelActive;

        UpdateData();
        ToggleVisualEffects();

        m_weaponWheelVisuals.SetActive(m_isWeaponWheelActive);
    }

    private void ToggleVisualEffects()
    {
        if (m_isWeaponWheelActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.5f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
    private void UpdateData()
    {
        WeaponData data;

        for (int i = 0; i <= transform.childCount; i++)
        {
            WeaponWheelButton weaponWheelButton = m_weaponWheelVisuals.transform.GetChild(i).GetComponent<WeaponWheelButton>();
            //GunData data = m_weaponSelector.GetWeaponData(i);
            m_weaponSelector.GetWeaponData(i, out data.Sprite, out data.Ammo, out data.MaxAmmo);
            weaponWheelButton.ID = i;
            weaponWheelButton.Setup(data.Sprite, data.Ammo, data.MaxAmmo);
        }
    }

    private void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.toggleWeaponWheel += ToggleWeaponWheel;
    }

    private void OnDisable()
    {
        StarterAssets.StarterAssetsInputs.toggleWeaponWheel -= ToggleWeaponWheel;
    }
}
