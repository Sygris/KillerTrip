using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelSystem : MonoBehaviour
{
    private int _currentLevel = 0;
    private float _currentXP = 0;
    private float _requiredXP = 0;

    private float _lerpTimer;
    private float _delayTimer;

    [Header("UI References")]
    [SerializeField] private Image _backBarXP;
    [SerializeField] private Image _frontBarXP;
    [SerializeField] private TextMeshProUGUI _currentLevelUI;
    [SerializeField] private TextMeshProUGUI _nextLevelUI;

    [Header("Required XP Formula")]
    [Range(1f, 300f)]
    [SerializeField] private float _additionMultiplier = 300;
    [Range(2f, 4f)]
    [SerializeField] private float _powerMultiplier = 2;
    [Range(7f, 14f)]
    [SerializeField] private float _divisionMultiplier = 7;

    private void Start()
    {
        _frontBarXP.fillAmount = _currentXP / _requiredXP;
        _backBarXP.fillAmount = _currentXP / _requiredXP;

        _currentLevelUI.text = _currentLevel.ToString();
        _nextLevelUI.text = (_currentLevel + 1).ToString();

        _requiredXP = CalculateRequiredXP();
    }

    private void Update()
    {
        UpdateUI();
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GainExperience(20);
        }
    }

    private void UpdateUI()
    {
        float xpFraction = _currentXP / _requiredXP;
        float frontBarXP = _frontBarXP.fillAmount;

        if (frontBarXP < xpFraction)
        {
            _delayTimer += Time.deltaTime;
            _backBarXP.fillAmount = xpFraction;

            if (_delayTimer > 3)
            {
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / 4;
                _frontBarXP.fillAmount = Mathf.Lerp(frontBarXP, _backBarXP.fillAmount, percentComplete);
            }
        }
    }

    public void GainExperience(float amount)
    {
        _currentXP += amount;

        if (_currentXP > _requiredXP)
        {
            LevelUp();
        }

        _lerpTimer = 0;
        _delayTimer = 0;
    }

    // Passed Level = Level of the enemy or of the level
    public void GainScalableExperience(float amount, int passedLevel)
    {
        if (passedLevel < _currentLevel)
        {
            float multiplier = 1 + (_currentLevel - passedLevel) * 0.01f;
            _currentXP += amount * multiplier;
        }
        else
        {
            _currentXP += amount;
        }

        _lerpTimer = 0;
        _delayTimer = 0;
    }

    private void LevelUp()
    {
        ++_currentLevel;
        
        _currentLevelUI.text = _currentLevel.ToString();
        _nextLevelUI.text = (_currentLevel + 1).ToString();

        _frontBarXP.fillAmount = 0;
        _backBarXP.fillAmount = 0;

        _currentXP = Mathf.RoundToInt(_currentXP - _requiredXP);

        _requiredXP = CalculateRequiredXP();
    }

    // Using runescpae formula = https://oldschool.runescape.wiki/w/Experience
    private int CalculateRequiredXP()
    {
        int solveForRequiredXP = 0;

        for (int levelCycle = 1; levelCycle <= _currentLevel; levelCycle++)
        {
            solveForRequiredXP += (int)Mathf.Floor(levelCycle + _additionMultiplier * Mathf.Pow(_powerMultiplier, levelCycle / _divisionMultiplier));
        }

        return solveForRequiredXP / 4;
    }
}
