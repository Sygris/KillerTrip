using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimultaneousObjectivesManager : ObjectivesManager
{
    protected void ObjectiveIsComplete(GameObject target)
    {
        target.SetActive(false);
    }
}
