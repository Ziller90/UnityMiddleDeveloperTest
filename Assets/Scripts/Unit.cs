using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Health unitHealth;

    void OnEnable()
    {
        unitHealth = GetComponent<Health>();
        if (unitHealth)
            unitHealth.dieEvent += () => Service<UnitsService>.Instance.UnregisterUnit(gameObject);
    }

    void OnDisable()
    {
        if (unitHealth)
            unitHealth.dieEvent -= () => Service<UnitsService>.Instance.UnregisterUnit(gameObject);
    }

    void Start() {
        Service<UnitsService>.Instance.RegisterUnit(gameObject);
    }
}
