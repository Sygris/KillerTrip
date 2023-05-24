using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour
{
    [SerializeField] private GameObject m_weaponWheelVisuals;
    private bool m_isWeaponWheelActive = false;

    private void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.toggleWeaponWheel += Test;
    }

    private void OnDisable()
    {
        StarterAssets.StarterAssetsInputs.toggleWeaponWheel -= Test;
    }

    private void Test()
    {
        m_isWeaponWheelActive = !m_isWeaponWheelActive;

        m_weaponWheelVisuals.SetActive(m_isWeaponWheelActive);
    }
}
