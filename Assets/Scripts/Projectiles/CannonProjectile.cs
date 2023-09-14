using UnityEngine;
using System.Collections;

public class CannonProjectile : ProjectileBase
{
	void FixedUpdate () 
	{
        if (target == null)
            Destroy(gameObject);
        
		transform.position += transform.forward * speed * Time.fixedDeltaTime;
	}
}
