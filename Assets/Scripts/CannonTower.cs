using UnityEngine;
using System.Collections;

public class CannonTower : MonoBehaviour {
    [SerializeField] float shootInterval = 0.5f;
    [SerializeField] float range = 4f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPoint;

	private float lastShotTime = -0.5f;

	void Update () {
		if (projectilePrefab == null || shootPoint == null)
			return;

		foreach (var monster in FindObjectsOfType<UnitMover>()) {
			if (Vector3.Distance (transform.position, monster.transform.position) > range)
				continue;

			if (lastShotTime + shootInterval > Time.time)
				continue;

			Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

			lastShotTime = Time.time;
		}
	}
}
