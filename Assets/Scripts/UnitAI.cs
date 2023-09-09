using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    [SerializeField] float reachDistance = 0.3f;

    GameObject moveTarget;
    UnitMover unitMover;

    private void Awake()
    {
        unitMover = GetComponent<UnitMover>();
    }

    public void SetMoveTarget(GameObject moveTarget)
    {
        this.moveTarget = moveTarget;
        unitMover.SetMoveTarget(moveTarget);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, moveTarget.transform.position) <= reachDistance)
        {
            Service<UnitsService>.Instance.UnregisterUnit(gameObject);
            Destroy(gameObject);
            return;
        }
    }
}
