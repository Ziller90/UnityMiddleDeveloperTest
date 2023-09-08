using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	[SerializeField] float spawnInterval = 3;
	[SerializeField] GameObject moveTarget;
	[SerializeField] GameObject unitPrefab;

	private float lastSpawnTime = -1;

	void Update () {
		if (Time.time > lastSpawnTime + spawnInterval) {
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
