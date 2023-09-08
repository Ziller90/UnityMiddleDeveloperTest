using UnityEngine;
using System.Collections;

public class SimpleTower : MonoBehaviour {
    [SerializeField] float shootInterval = 0.5f;
    [SerializeField] float range = 4f;
    [SerializeField] GameObject projectilePrefab;

	private float m_lastShotTime = -0.5f;
	
	void Update () {
		if (projectilePrefab == null)
			return;

		foreach (var monster in FindObjectsOfType<UnitMover>()) {
			if (Vector3.Distance (transform.position, monster.transform.position) > range)
				continue;

			if (m_lastShotTime + shootInterval > Time.time)
				continue;

			Shot(monster.gameObject);
        }
	}

	void Shot(GameObject target) {
        var projectile = Instantiate(projectilePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        var projectileBeh = projectile.GetComponent<GuidedProjectile>();
		projectileBeh.SetTarget(target);

        m_lastShotTime = Time.time;
    }
}
