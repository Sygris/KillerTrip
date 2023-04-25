using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObjective : ObjectiveManager
{
    [SerializeField] List<GameObject> _targetObjects = new List<GameObject>();

    //public override void RunObjective()
    //{
    //    if (_targetObjects.Count <= 0)
    //        ObjectiveComplete();

    //    foreach (var item in _targetObjects)
    //    {
    //        if (!item.activeSelf)
    //            _targetObjects.Remove(item);
    //    }
    //}

    private void Update()
    {
        if (_targetObjects.Count > 0)
        {
            foreach (var item in _targetObjects)
            {
                if (!item.activeInHierarchy)
                {
                    _targetObjects.Remove(item);
                    break;
                }
            }
        }
        else
            gameObject.SetActive(false);
    }
}
