using UnityEngine;
using System.Collections;

public class GuidedProjectile : ProjectileBase
{ 
	void FixedUpdate () 
	{
		if (target == null)
			return;

		var translation = target.transform.position - transform.position;
		if (translation.magnitude > speed) {
			translation = translation.normalized * speed;
		}
		transform.Translate (translation);
	}
}
