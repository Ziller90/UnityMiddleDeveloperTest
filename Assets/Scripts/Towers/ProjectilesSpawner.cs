using UnityEngine;
using System.Collections;

public class ProjectilesSpawner : MonoBehaviour 
{
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] float range;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnPoint;

    float lastSpawnTime = -0.5f;
    GameObject attackTarget;

    public void SetAttackTarget(GameObject target)
    {
        attackTarget = target;
    }

    void FixedUpdate () 
    {
		if (projectilePrefab && attackTarget)
            Attack();
	}

    void Attack()
    {
        if (lastSpawnTime + spawnInterval < Time.time)
        {
            Shot();
            lastSpawnTime = Time.time;
        }
    }

    void Shot()
    {
        var projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        var projectileBeh = projectile.GetComponent<ProjectileBase>();
		projectileBeh.SetTarget(attackTarget);
    }
}
