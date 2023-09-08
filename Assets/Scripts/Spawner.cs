using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	[SerializeField] float spawnInterval = 3;
	[SerializeField] GameObject moveTarget;

	private float lastSpawnTime = -1;

	void Update () {
		if (Time.time > lastSpawnTime + spawnInterval) {
			var newMonster = GameObject.CreatePrimitive (PrimitiveType.Capsule);
			var rigidBody = newMonster.AddComponent<Rigidbody> ();
			rigidBody.useGravity = false;
			newMonster.transform.position = transform.position;
			var monsterBeh = newMonster.AddComponent<UnitMover> ();
			monsterBeh.SetMoveTarget(moveTarget);

			lastSpawnTime = Time.time;
		}
	}
}
