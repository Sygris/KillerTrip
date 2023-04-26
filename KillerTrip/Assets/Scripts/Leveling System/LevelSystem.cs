using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelSystem : MonoBehaviour
{
    private int _currentLevel = 0;
    private float _currentXP = 5;
    private float _requiredXP = 10;

    private float _lerpTimer;
    private float _delayTimer;

    [Header("UI References")]
    [SerializeField] private Image _backBarXP;
    [SerializeField] private Image _frontBarXP;
    [SerializeField] private TextMeshProUGUI _currentLevelUI;
    [SerializeField] private TextMeshProUGUI _nextLevelUI;

    private void Start()
    {
        _frontBarXP.fillAmount = _currentXP / _requiredXP;
        _backBarXP.fillAmount = _currentXP / _requiredXP;

        _currentLevelUI.text = _currentLevel.ToString();
        _nextLevelUI.text = (_currentLevel + 1).ToString();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            _currentXP += 5;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {

    }


}
