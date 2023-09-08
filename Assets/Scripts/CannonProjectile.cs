using UnityEngine;
using System.Collections;

public class CannonProjectile : MonoBehaviour {
	[SerializeField] float speed = 0.2f;
    [SerializeField] int damage = 10;

	void Update () {
		var translation = transform.forward * speed;
		transform.Translate(translation);
	}

	void OnTriggerEnter(Collider other) {
		var monsterHealth = other.gameObject.GetComponent<Health> ();
		if (monsterHealth == null)
			return;

		monsterHealth.DeliverDamage(damage);
		Destroy (gameObject);
	}
}
