using UnityEngine;
using System.Collections;

public class GuidedProjectile : ProjectileBase
{ 
	void FixedUpdate () 
	{
		if (target == null)
			Destroy(gameObject);

		var targetDirection = target.transform.position - transform.position;
		transform.position += targetDirection.normalized * speed * Time.fixedDeltaTime;
	}
}
