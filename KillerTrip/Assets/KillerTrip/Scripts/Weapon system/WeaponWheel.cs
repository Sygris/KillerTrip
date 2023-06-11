using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    [SerializeField] private GameObject m_weaponWheelVisuals;
    private bool m_isWeaponWheelActive = false;

    private void Start()
    {
        m_weaponWheelVisuals.SetActive(false);
    }

    private void ToggleWeaponWheel()
    {
        m_isWeaponWheelActive = !m_isWeaponWheelActive;

        ToggleVisualEffects();

        m_weaponWheelVisuals.SetActive(m_isWeaponWheelActive);
    }

    private void ToggleVisualEffects()
    {
        if (m_isWeaponWheelActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.35f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
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
