using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveObjectivesManager : MonoBehaviour
{
    private List<GameObject> _listOfConsecutiveObjectives = new List<GameObject>();

    private int _currentObjective;

    void Start()
    {
        _currentObjective = 0;

        foreach (Transform item in gameObject.transform.GetComponentInChildren<Transform>())
            _listOfConsecutiveObjectives.Add(item.gameObject);

        foreach (var item in _listOfConsecutiveObjectives)
            item.SetActive(false);

        _listOfConsecutiveObjectives[_currentObjective].SetActive(true);
    }

    public void ObjectiveIsComplete()
    {
        _listOfConsecutiveObjectives[_currentObjective].SetActive(false);

        ++_currentObjective;

        if (_currentObjective < _listOfConsecutiveObjectives.Count)
            _listOfConsecutiveObjectives[_currentObjective].SetActive(true);
    }
}