using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _interactText;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _health;

    [SerializeField] private Image _interactImage;
    [SerializeField] private Sprite _defaultInteractIcon;

    [SerializeField] private Image _staminaBar;

    private PlayerStats _playerStats;

    public void EmptyInteractMessage()
    {
        _interactText.text = "";
    }

    public void UpdateInteractText(string text)
    {
        _interactText.text = text;
    }

    public void EmptyInteractIcon()
    {
        _interactImage.sprite = _defaultInteractIcon;
    }

    public void UpdateInteractIcon(Sprite icon)
    {
        if (_interactImage == null)
            EmptyInteractIcon();
        else
            _interactImage.sprite = icon;
    }

    public void EmptyMoneyMessage()
    {
        _moneyText.text = "";
    }

    public void UpdateMoneyText()
    {
        _moneyText.text = _playerStats.GetPlayerMoney().ToString();
    }

    private void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _health.text = _playerStats.GetPlayerCurrentHealth().ToString();
    }

    private void Update()
    {
        //_health.fillAmount = _playerStats.GetPlayerCurrentHealth() / _playerStats.GetPlayerMaxHealth();
        _health.text = _playerStats.GetPlayerCurrentHealth().ToString();
        _staminaBar.fillAmount = _playerStats.GetPlayerCurrentStamina() / _playerStats.GetPlayerMaxStamina();

        UpdateMoneyText();
    }
}
