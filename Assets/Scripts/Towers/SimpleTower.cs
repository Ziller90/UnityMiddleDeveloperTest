using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : MonoBehaviour
{
    ProjectilesSpawner projectilesSpawner;
    UnitDetector unitsDectector;

    void OnEnable()
    {
        unitsDectector = GetComponent<UnitDetector>();
        projectilesSpawner = GetComponent<ProjectilesSpawner>();

        unitsDectector.attackTargetUpdatedEvent += SetTarget;
    }

    void OnDisable()
    {
        unitsDectector.attackTargetUpdatedEvent -= SetTarget;
    }

    void SetTarget(GameObject target)
    {
        projectilesSpawner.SetAttackTarget(target);
    }
}
