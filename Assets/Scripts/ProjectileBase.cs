using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] protected float speed = 0.2f;

    protected GameObject target;

    public delegate void TargetReached(GameObject target);
    public event TargetReached targetReached;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject == target)
            targetReached(other.gameObject);
    }
}
