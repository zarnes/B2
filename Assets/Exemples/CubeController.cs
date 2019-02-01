using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float Speed;
    public float Force;
    public LayerMask Layermask;

    private bool _inAir = false;
    private float _nextRay = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("coucou !");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float timescale = Time.deltaTime;

        transform.position = transform.position + new Vector3(x * timescale * Speed, 0, z * timescale * Speed);

        if (Input.GetKeyDown(KeyCode.Space) && !_inAir)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * timescale * Force, ForceMode.Impulse);
            _inAir = true;
        }
        
        if (Time.time > _nextRay)
        {
            _nextRay = Time.time + 0.5f;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10, Layermask))
            {
                Debug.Log(hit.transform.name);
            }
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red, 0.5f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        _inAir = false;
    }
}
