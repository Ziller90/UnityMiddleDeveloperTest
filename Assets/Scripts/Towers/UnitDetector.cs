using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitDetector : MonoBehaviour
{
    Range range;
    UnitsService unitsService;
    GameObject attackTarget;

    Queue<GameObject> targetsQueue = new Queue<GameObject>();

    public delegate void AttackTargetUpdated(GameObject attackTarget);
    public event AttackTargetUpdated attackTargetUpdatedEvent;

    void Start()
    {
        unitsService = Service<UnitsService>.Instance;
        range = GetComponent<Range>();  
    }

    void Update()
    {
        EnqueueTargetsInRange();
        FindAttackTargetInQueue();
    }

    void EnqueueTargetsInRange()
    {
        foreach (var unit in unitsService.UnitsOnLocation)
        {
            if (range.IsObjectInRange(unit) && !targetsQueue.Contains(unit))
            {
                targetsQueue.Enqueue(unit);
            }
        }
    }

    void FindAttackTargetInQueue()
    {
        GameObject newAttackTarget = null;

        while (newAttackTarget == null && targetsQueue.Count != 0)
        {
            var peek = targetsQueue.Peek();
            if (peek && range.IsObjectInRange(peek))
            {
                newAttackTarget = peek;
            }
            else
            {
                targetsQueue.Dequeue();
            }
        }

        if (newAttackTarget != attackTarget)
        {
            attackTarget = newAttackTarget;
            attackTargetUpdatedEvent?.Invoke(attackTarget);
        }
    }
}
