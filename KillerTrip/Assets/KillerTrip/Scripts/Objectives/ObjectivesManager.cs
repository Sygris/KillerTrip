using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _objectiveTitleText;
    [SerializeField] protected TextMeshProUGUI _objectiveQuantityText;

    [SerializeField] protected string _objectiveTitle;
    [SerializeField] protected List<GameObject> _targetObjects = new List<GameObject>();
    [SerializeField] protected bool _isConsecutiveObjective = false;

    protected ObjectivesManager _objectivesManager;

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

        _listOfConsecutiveObjectives[_currentObjective].SetActive(true);
    }
}
