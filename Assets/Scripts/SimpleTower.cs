using UnityEngine;
using System.Collections;

public class SimpleTower : MonoBehaviour {
    [SerializeField] float shootInterval = 0.5f;
    [SerializeField] float range;
    [SerializeField] GameObject projectilePrefab;

	private float lastShotTime = -0.5f;
    UnitsService unitsService;

    private void Start() {
        unitsService = Service<UnitsService>.Instance;
    }
    
    void Update () {
		if (projectilePrefab == null)
			return;

		foreach (var unit in unitsService.UnitsOnLocation) {
			if (Vector3.Distance (transform.position, unit.transform.position) > range)
			{
				Debug.Log(Vector3.Distance(transform.position, unit.transform.position));
                continue;
            }


			if (lastShotTime + shootInterval > Time.time)
				continue;

			Shot(unit.gameObject);
        }
	}

	void Shot(GameObject target) {
        var projectile = Instantiate(projectilePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        var projectileBeh = projectile.GetComponent<GuidedProjectile>();
		projectileBeh.SetTarget(target);

        lastShotTime = Time.time;
    }
}
