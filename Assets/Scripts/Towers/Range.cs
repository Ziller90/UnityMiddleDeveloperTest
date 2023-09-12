using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Color rangeColor;

    public bool IsObjectInRange(GameObject obj)
    {
        return Vector3.Distance(gameObject.transform.position, obj.transform.position) < range;
    }

    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject == gameObject)
        {
            Gizmos.color = rangeColor;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
