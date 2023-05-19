using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObjective : ObjectivesManager
{
    [SerializeField] private string _objectiveTitle;
    [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();
    [SerializeField] private bool _isConsecutiveObjective = false;

    private ObjectivesManager _objectivesManager;

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
