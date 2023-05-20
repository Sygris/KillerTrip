using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerObjective : ObjectivesManager
{
    void Start()
    {
        _objectivesManager = transform.parent.GetComponent<ObjectivesManager>();

        _objectiveTitleText.text = _objectiveTitle;
        _objectiveQuantityText.text = _targetObjects.Count.ToString();
    }

    void Update()
    {
        foreach (GameObject item in _targetObjects)
        {
            if (item.layer == 0)
                _targetObjects.Remove(item);
        }

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
