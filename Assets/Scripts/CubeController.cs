using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float Speed;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed space !");
        }
    }
}
