using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsService : MonoBehaviour
{
    List<GameObject> unitsOnLocation = new List<GameObject>();

    public IReadOnlyList<GameObject> UnitsOnLocation => unitsOnLocation;

    public void RegisterUnit(GameObject unit)
    {
        if (!unitsOnLocation.Contains(unit))
            unitsOnLocation.Add(unit);
    }

    public void UnregisterUnit(GameObject unit)
    {
        if (unitsOnLocation.Contains(unit))
            unitsOnLocation.Remove(unit);
    }
}
