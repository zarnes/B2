using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGravity : MonoBehaviour
{
    public Vector3 Gravity = Vector3.down;
    public float RaycastDistance = 2f;
    public LayerMask Mask;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.up * RaycastDistance, Color.red);
        if (Physics.Raycast(transform.position, -transform.up, out hit, RaycastDistance, Mask))
        {
            Debug.Log(hit.transform.name);
            Vector3 normal = hit.normal;
            Gravity = -normal;
        }
    }

    private void FixedUpdate()
    {
        transform.position += Gravity * Time.fixedDeltaTime;
    }
}
