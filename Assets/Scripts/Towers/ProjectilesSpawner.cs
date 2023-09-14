using UnityEngine;
using System.Collections;

public class ProjectilesSpawner : MonoBehaviour 
{
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] float range;
    [SerializeField] ProjectileBase projectilePrefab;
    [SerializeField] Transform spawnPoint;

    public Transform SpawnPoint => spawnPoint;
    public ProjectileBase ProjectilePrefab => projectilePrefab; 

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
        var projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.SetTarget(attackTarget);
    }
}
