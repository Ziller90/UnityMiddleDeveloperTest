using UnityEngine;
using System.Collections;

public class CannonTower : MonoBehaviour {
    [SerializeField] float shootInterval = 0.5f;
    [SerializeField] float range = 4f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPoint;

	private float lastShotTime = -0.5f;
	UnitsService unitsService;

    private void Start() {
		unitsService = Service<UnitsService>.Instance;
	}

    void Update () {
		if (projectilePrefab == null || shootPoint == null)
			return;

		foreach (var unit in unitsService.UnitsOnLocation) {
			if (Vector3.Distance (transform.position, unit.transform.position) > range)
				continue;

			if (lastShotTime + shootInterval > Time.time)
				continue;

			Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

			lastShotTime = Time.time;
		}
	}
}
