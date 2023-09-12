using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    public float ProjectileSpeed { get; set; }
    float projectileSpeed;

    GameObject target;

    Vector3 ATargetPosition;
    Vector3 BTargetPosition;

    Vector3 targetVelocity;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Update()
    {
        ATargetPosition = BTargetPosition;
        BTargetPosition = target.transform.position;

        targetVelocity = BTargetPosition - ATargetPosition;

        if (target)
        {

        }
    }
}
