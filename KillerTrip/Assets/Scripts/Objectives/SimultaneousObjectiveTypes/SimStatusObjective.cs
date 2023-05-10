using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimStatusObjective : SimultaneousObjectivesManager
{
    [SerializeField] private string _objectiveTitle;
    [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

    void Start()
    {
        _objectiveTitleText.text = _objectiveTitle;
        _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }

    void Update()
    {
        if (_targetObjects.Count <= 0)
            ObjectiveIsComplete(gameObject);
        else
            _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }
}
