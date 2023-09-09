using UnityEngine;
using System.Collections;

public class CannonProjectile : ProjectileBase
{
	void FixedUpdate () 
	{
        if (target == null)
            return;
        
		var translation = transform.forward * speed;
		transform.Translate(translation);
	}
}
