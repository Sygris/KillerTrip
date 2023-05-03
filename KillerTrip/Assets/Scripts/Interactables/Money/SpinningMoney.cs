using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningMoney : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;

    void Update()
    {
        transform.Rotate(0f, _spinSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
