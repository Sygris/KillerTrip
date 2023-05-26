using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    [SerializeField] private GameObject m_weaponWheelVisuals;
    private bool m_isWeaponWheelActive = false;

    [Serializable]
    public class WheelSlot
    {
        public Sprite HighlightSprite;
        private Sprite m_defaultSprite;
        public Image Slot;

        public Sprite DefaultSprite
        {
            get => m_defaultSprite;
            set => m_defaultSprite = value;
        }
    }

    [SerializeField] private List<WheelSlot> m_slots = new List<WheelSlot>();

    private void Start()
    {
        m_weaponWheelVisuals.SetActive(false);

        foreach (WheelSlot wheelSlot in m_slots)
        {
            wheelSlot.DefaultSprite = wheelSlot.Slot.sprite;
        }
    }

    private void ToggleWeaponWheel()
    {
        m_isWeaponWheelActive = !m_isWeaponWheelActive;

        m_weaponWheelVisuals.SetActive(m_isWeaponWheelActive);
    }

    private void EnableHighlight(int index)
    {
        for (int i = 0; i < m_slots.Count; i++)
        {
            if (m_slots[i].Slot != null && m_slots[i].HighlightSprite != null)
            {
                if (i == index)
                {
                    m_slots[i].Slot.sprite = m_slots[i].HighlightSprite;
                }
                else
                {
                    m_slots[i].Slot.sprite = m_slots[i].DefaultSprite;
                }
            }
        }
    }

    private void DisableHighlight(int index)
    {
        for (int i = 0; i < m_slots.Count; i++)
        {
            if (m_slots[i].Slot != null)
            {
                m_slots[i].Slot.sprite = m_slots[i].DefaultSprite;
            }
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
