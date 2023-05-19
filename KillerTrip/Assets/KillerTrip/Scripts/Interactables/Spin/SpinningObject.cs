using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;

    void Start()
    {
        if (_spinSpeed == 0)
            _spinSpeed = 200;
    }

    void Update()
    {
        transform.Rotate(0f, _spinSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
