using UnityEngine;
using System.Collections;

public class CannonProjectile : ProjectileBase
{
	void FixedUpdate () 
	{
		if (target)
			transform.position += transform.forward * speed * Time.fixedDeltaTime;
	}
}
