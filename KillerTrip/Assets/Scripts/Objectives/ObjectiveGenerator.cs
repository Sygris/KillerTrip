using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveGenerator : MonoBehaviour
{
    [Tooltip("Add objectives in order of completion")]
    [SerializeField] List<GameObject> _consecutiveObjectives = new List<GameObject>();
    [Tooltip("UI Text Elemet for Consecutive Objectives")]
    [SerializeField] private TextMeshProUGUI _consecutiveObjectivesText;
    private int _currentConsecutiveObjective;

    [Tooltip("Add all simultaneous objectived, no order needed")]
    [SerializeField] List<GameObject> _simultaneousObjectives = new List<GameObject>();
    [Tooltip("UI GameObject Elemet for Simultaneous Objectives")]
    [SerializeField] private GameObject _simultaneousObjectiveUI;
    [Tooltip("Simultaneous Objectives Text Prefab")]
    [SerializeField] private GameObject _simultaneousObjectivesText;

    public enum ObjectiveMenu
    {
        KeyPress,
        Status
    };
    [SerializeField] private ObjectiveMenu _objectiveType;

    [Tooltip("'Objective Type': 'Objective Title'")]
    [SerializeField] private string _objectiveTitle;
    [Tooltip("Location of the objective. Default 0, 0, 0")]
    [SerializeField] private Transform _objectiveLocation;

    public void GenerateObjective()
    {
        GameObject objective = new GameObject(_objectiveType.ToString() + ": " + _objectiveTitle);

        if (_objectiveLocation != null)
            objective.transform.position = _objectiveLocation.transform.position;

        objective.transform.SetParent(transform);

        objective.AddComponent<ObjectiveManager>();

        switch (_objectiveType)
        {
            case ObjectiveMenu.KeyPress:
                objective.AddComponent<KeyPressObjective>();
                break;
            case ObjectiveMenu.Status:
                objective.AddComponent<StatusObjective>();
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        foreach (var item in _consecutiveObjectives)
            item.SetActive(false);

        _consecutiveObjectives[_currentConsecutiveObjective].SetActive(true);

        _consecutiveObjectivesText.text = _consecutiveObjectives[_currentConsecutiveObjective].GetComponent<ObjectiveManager>().GetObjectivedText();

        UpdateSimultaneousObjective();
    }

    private void Update()
    {
        foreach (var item in _simultaneousObjectives)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                _simultaneousObjectives.Remove(item);
                UpdateSimultaneousObjective();
                break;
            }
        }

        if (!_consecutiveObjectives[_currentConsecutiveObjective].gameObject.activeInHierarchy)
            NextConsecutiveObjective();
    }

    private void UpdateSimultaneousObjective()
    {
        foreach (Transform item in _simultaneousObjectiveUI.transform)
            Destroy(item.gameObject);

        foreach (var item in _simultaneousObjectives)
        {
            GameObject simObj = Instantiate(_simultaneousObjectivesText, _simultaneousObjectiveUI.transform);

            simObj.GetComponent<TextMeshProUGUI>().text = item.GetComponent<ObjectiveManager>().GetObjectivedText();
        }
    }

    private void NextConsecutiveObjective()
    {
        _consecutiveObjectives[_currentConsecutiveObjective].gameObject.SetActive(false);

        ++_currentConsecutiveObjective;

        _consecutiveObjectivesText.text = _consecutiveObjectives[_currentConsecutiveObjective].GetComponent<ObjectiveManager>().GetObjectivedText();

        _consecutiveObjectives[_currentConsecutiveObjective].SetActive(true);
    }

}
