using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public Collider2D detectedObjs;
    public float viewRadius;
    public LayerMask playerLayerMask;
    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        if (collider != null )
        {
            detectedObjs = collider;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
