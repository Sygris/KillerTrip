using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _currentStamina;
    [SerializeField] private int _currentMoney;

    [Header("Player Movement")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;
    private CharacterController _playerController;
    private Vector3 _playerVelocity;
    private float _playerGravity = -9.8f;

    [Header("Player Look")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float _xAxisSensitivity;
    [SerializeField] private float _yAxisSensitivity;
    [SerializeField] private float _viewClampUp;
    [SerializeField] private float _viewClampDown;

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
    }

    #region PlayerComponentsAndGeneralStuff
    public CharacterController GetPlayerCharacterController() { return _playerController; }

    public Vector3 GetPlayerVector() { return _playerVelocity; }
    public void UpdatePlayerVector(float xValue, float yValue, float zValue)
    {
        _playerVelocity.x += xValue;
        _playerVelocity.y += yValue;
        _playerVelocity.z += zValue;
    }    
    public void SetPlayerVector(float xValue, float yValue, float zValue)
    {
        _playerVelocity.x = xValue;
        _playerVelocity.y = yValue;
        _playerVelocity.z = zValue;
    }
    public void SetPlayerVector(Vector3 vector)
    {
        _playerVelocity = vector;
    }
    public float GetPlayerXVector() { return _playerVelocity.x; }
    public float GetPlayerYVector() { return _playerVelocity.y; }
    public float GetPlayerZVector() { return _playerVelocity.z; }
    public void SetPlayerXVector(float value) { _playerVelocity.x = value; }
    public void SetPlayerYVector(float value) { _playerVelocity.y = value; }
    public void SetPlayerZVector(float value) { _playerVelocity.z = value; }

    public float GetPlayerGravity() { return _playerGravity; }
    #endregion

    #region PlayerHealth
    public int GetPlayerCurrentHealth() { return _currentHealth; }
    public int GetPlayerMaxHealth() { return _maxHealth; }

    public void UpdatePlayerHealth(int value)
    {
        _currentHealth += value;

        if (IsPlayerAtMaxHealth()) { _currentHealth = _maxHealth; }

        if (IsPlayerAtMinHealth()) { _currentHealth = 0; }
    }

    private bool IsPlayerAtMaxHealth() { return _currentHealth >= _maxHealth; }
    private bool IsPlayerAtMinHealth() { return _currentHealth <= 0.0f; }
    #endregion

    #region PlayerStamina
    public float GetPlayerCurrentStamina() { return _currentStamina; }
    public float GetPlayerMaxStamina() { return _maxStamina; }

    public void UpdatePlayerStamina(float value)
    {
        _currentStamina += value;

        if (IsPlayerAtMaxStamina()) { _currentStamina = _maxStamina; }

        if (IsPlayerAtMinStamina()) { _currentStamina = 0.0f; }
    }

    private bool IsPlayerAtMaxStamina() { return _currentStamina >= _maxStamina; }
    private bool IsPlayerAtMinStamina() { return _currentStamina <= 0.0f; }
    #endregion

    #region PlayerMoney
    public int GetPlayerMoney() { return _currentMoney; }
    public void UpdatePlayerMoney(int value) { _currentMoney += value; }
    #endregion

    #region PlayerMovement
    public float GetPlayerMovementSpeed() { return _movementSpeed; }
    public void SetPlayerMovementSpeed(float Speed) { _movementSpeed = Speed; }
    #endregion

    #region PlayerJump
    public float GetPlayerJumpHeight() { return _jumpHeight; }
    public void SetPlayerJumpHeigt(float JumpHeight) { _jumpHeight = JumpHeight; }
    #endregion

    #region PlayerLook
    public Camera GetPlayerCamera() { return _camera; }
    
    public float GetPlayerXAxisSensitivity() { return _xAxisSensitivity; }
    public float GetPlayerYAxisSensitivity() { return _yAxisSensitivity; }
    public float GetPlayerViewClampUp() { return _viewClampUp; }
    public float GetPlayerViewClampDown() { return _viewClampDown; }
    #endregion
}
