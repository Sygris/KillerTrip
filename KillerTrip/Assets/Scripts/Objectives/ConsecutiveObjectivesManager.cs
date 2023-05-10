using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveObjectivesManager : ObjectivesManager
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

    void Update()
    {
        Debug.Log(_listOfConsecutiveObjectives.Count);
    }

    protected void ObjectiveIsComplete()
    {
        Debug.Log(_listOfConsecutiveObjectives.Count);

        _listOfConsecutiveObjectives[_currentObjective].SetActive(false);

        ++_currentObjective;

        _listOfConsecutiveObjectives[_currentObjective].SetActive(true);
    }
}
