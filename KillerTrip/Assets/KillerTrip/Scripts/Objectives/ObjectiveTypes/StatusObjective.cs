using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObjective : ObjectivesManager
{
    void Start()
    {
        _objectivesManager = transform.parent.GetComponent<ObjectivesManager>();

        _objectiveTitleText.text = _objectiveTitle;
        _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }

    void Update()
    {
        if (_targetObjects.Count <= 0)
        {
            if (_isConsecutiveObjective)
                _objectivesManager.ObjectiveIsComplete();
            else
                gameObject.SetActive(false);
        }
        else
            _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }
}
