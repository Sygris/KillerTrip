using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ObjectiveManager : MonoBehaviour
{
    #region idea1
    [SerializeField] private string _objectiveText;
    protected bool _isCompleted;
    protected bool _isFailed;

    public string GetObjectivedText() { return _objectiveText; }
    public bool IsObjectiveComplete() { return _isCompleted; }
    public bool IsObjectiveFailed() { return _isCompleted; }

    protected void ObjectiveComplete() { _isCompleted = true; }

    protected void ObjectiveFailed() { _isFailed = true; }
    #endregion

    #region idea2
    //public enum ObejectiveType
    //{
    //    Status,
    //    KeyPress
    //}; public ObejectiveType ObjectiveMenu;

    //public StatusParameters Status;
    //[System.Serializable]
    //public class StatusParameters
    //{
    //    [SerializeField] List<GameObject> _targetObjects = new List<GameObject>();

    //    public void RunObjective()
    //    {
    //        if (_targetObjects.Count <= 0)
    //            // disable gameobject

    //        foreach (var item in _targetObjects)
    //        {
    //            if (!item.activeSelf)
    //                _targetObjects.Remove(item);
    //        }
    //    }
    //}

    //public KeyPressParameters KeyPress;
    //[System.Serializable]
    //public class KeyPressParameters
    //{
    //    [SerializeField] List<KeyCode> _keysToPress = new List<KeyCode>();

    //    public void RunObjective()
    //    {
    //        foreach (var item in _keysToPress)
    //        {
    //            //if (item.)
    //            //{

    //            //}
    //        }
    //    }
    //}
    #endregion
}
