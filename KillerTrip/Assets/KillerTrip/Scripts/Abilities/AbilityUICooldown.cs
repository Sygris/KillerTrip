using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityUICooldown : MonoBehaviour
{
    [SerializeField] private float _cooldownTimer;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _quantityIcon;
    [SerializeField] private GameObject _quantityParent;
    [SerializeField] private GameObject _quantityChild;

    private Image _loader;

    private float _timer;
    private bool _isInUse;

    private void Start()
    {
        _loader = GetComponent<Image>();
        UpdateQuantity();
    }

    public void UseAbility()
    {
        if (AbilityNotInUse())
        {
            _isInUse = true;
            _loader.fillAmount = 1.0f;
            --_quantity;
            UpdateQuantity();
            StartCoroutine("AbilityDelay");
        }
    }

    private IEnumerator AbilityDelay()
    {
        _timer = 0.0f;

        while (true)
        {
            _timer += Time.deltaTime;

            _loader.fillAmount = (_timer / _cooldownTimer);

            if (_timer >= _cooldownTimer)
            {
                _isInUse = false;
                StopCoroutine("AbilityDelay");
            }
            yield return null;
        }
    }

    private bool AbilityNotInUse()
    {
        if (!_isInUse && _quantity > 0)
            return true;
        else
            return false;
    }

    private void UpdateQuantity()
    {
        DestroyQuantityChildren();

        for (int i = 0; i < _quantity; i++)
        {
            GameObject Icon = Instantiate(_quantityChild, _quantityParent.transform);

            if (i % 2 == 0)
                Icon.transform.Rotate(new Vector3(180.0f, 0.0f, 0.0f));
        }
    }

    private void DestroyQuantityChildren()
    {
        int i = 0;

        // Make temporary array for "child"
        GameObject[] _childQuantity = new GameObject[_quantityParent.transform.childCount];

        // Add number of children to array
        foreach (Transform child in _quantityParent.transform)
        {
            _childQuantity[i] = child.gameObject;
            ++i;
        }

        // Destroy the children
        foreach (GameObject child in _childQuantity)
            Destroy(child.gameObject);
    }
}
