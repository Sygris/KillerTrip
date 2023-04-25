using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPressObjective : ObjectiveManager
{
    [SerializeField] private List<KeyCode> _keysToPress = new List<KeyCode>();

    private void Update()
    {
        foreach (var key in _keysToPress)
        {

        }
    }
}
