using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConStatusObjective : ObjectivesManager
{
    [SerializeField] private string _objectiveTitle;
    [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

    private ConsecutiveObjectivesManager _consecutiveObjectivesManager;

    void Start()
    {
        _consecutiveObjectivesManager = FindObjectOfType<ConsecutiveObjectivesManager>();

        _objectiveTitleText.text = _objectiveTitle;
        _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }

    void Update()
    {
        if (_targetObjects.Count <= 0)
            _consecutiveObjectivesManager.ObjectiveIsComplete();
        else
            _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }
}
