using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamager : MonoBehaviour
{
    [SerializeField] float damage;

    ProjectileBase projectileBase;

    void Awake() => projectileBase = GetComponent<ProjectileBase>();
    void OnEnable() => projectileBase.targetReached += DeliverDamageToTarget;
    void OnDisable() => projectileBase.targetReached -= DeliverDamageToTarget;

    void DeliverDamageToTarget(GameObject target)
    {
        var targetHealth = target.GetComponent<Health>();
        if (targetHealth)
            targetHealth.DeliverDamage(damage);
        Destroy(gameObject);
    }
}
