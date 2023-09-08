using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 30f;
    private float currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void DeliverDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    void Die() {
        Destroy(gameObject);
    }
}
