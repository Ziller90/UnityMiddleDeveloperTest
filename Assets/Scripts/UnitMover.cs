using UnityEngine;
using System.Collections;

public class UnitMover : MonoBehaviour {
    [SerializeField] GameObject moveTarget;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float reachDistance = 0.3f;

	public void SetMoveTarget(GameObject moveTarget) {
		this.moveTarget = moveTarget;
    }

	void Update () {
		if (moveTarget == null)
			return;
		
		if (Vector3.Distance (transform.position, moveTarget.transform.position) <= reachDistance) {
			Destroy (gameObject);
			return;
		}

		var translation = moveTarget.transform.position - transform.position;
		if (translation.magnitude > speed) {
			translation = translation.normalized * speed;
		}
		transform.Translate (translation);
	}
}
