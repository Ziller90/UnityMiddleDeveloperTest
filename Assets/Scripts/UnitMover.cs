using UnityEngine;
using System.Collections;

public class UnitMover : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;

    GameObject moveTarget;

    public void SetMoveTarget(GameObject moveTarget)
    {
        this.moveTarget = moveTarget;
    }
    
	void FixedUpdate () 
	{
		if (moveTarget == null)
			return;

		var translation = moveTarget.transform.position - transform.position;
		if (translation.magnitude > speed)
		{
			translation = translation.normalized * speed;
		}
		transform.Translate (translation);
	}
}
