using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] float spawnInterval;
	[SerializeField] float spawnStartDelay;
	[SerializeField] GameObject moveTarget;
	[SerializeField] GameObject unitPrefab;

    float lastSpawnTime;

    void Start()
    {
		lastSpawnTime = -spawnStartDelay - spawnInterval;
    }

    void FixedUpdate () 
	{
		if (Time.time > lastSpawnTime + spawnInterval) 
		{
			SpawnUnit(unitPrefab);
            lastSpawnTime = Time.time;
		}
	}

	void SpawnUnit(GameObject unitPrefab)
	{
        var newUnit = Instantiate(unitPrefab, transform.position, Quaternion.identity);
        var unitAI = newUnit.GetComponent<UnitAI>();
        unitAI.SetMoveTarget(moveTarget);
    }
}
