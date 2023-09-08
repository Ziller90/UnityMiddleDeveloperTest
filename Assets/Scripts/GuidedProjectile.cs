using UnityEngine;
using System.Collections;

public class GuidedProjectile : MonoBehaviour {

    [SerializeField] float monsterSpeed = 0.2f;
    [SerializeField] int monsterDamage = 10;

    private GameObject target;

    public void SetTarget(GameObject target) {
		this.target = target;
	}

	void Update () {
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		var translation = target.transform.position - transform.position;
		if (translation.magnitude > monsterSpeed) {
			translation = translation.normalized * monsterSpeed;
		}
		transform.Translate (translation);
	}

	void OnTriggerEnter(Collider other) {
		var monster = other.gameObject.GetComponent<Health> ();
		if (monster == null)
			return;

		monster.DeliverDamage(monsterDamage);
		Destroy (gameObject);
	}
}
