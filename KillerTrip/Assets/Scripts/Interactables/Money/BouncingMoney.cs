using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingMoney : MonoBehaviour
{
    [SerializeField] private float _bounceDelay;
    [SerializeField] private float _bounceSpeed;

    private Rigidbody _myrigid;
    private float _current;
    private bool _isMovingUp;

    void Start()
    {
        _myrigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _current += Time.deltaTime;

        if (_isMovingUp)
        {
            _myrigid.velocity = transform.up * _bounceSpeed * Time.deltaTime;
        }
        else
        {
            _myrigid.velocity = transform.up * -_bounceSpeed * Time.deltaTime;

        }

        if (_current > _bounceDelay)
        {
            _isMovingUp = !_isMovingUp;

            _current = 0;
        }
    }
}
