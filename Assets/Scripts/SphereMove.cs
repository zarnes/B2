using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    private Animator _animator;
    float _nextInput;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _nextInput = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < _nextInput)
            return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0)
        {
            //_animator.SetTrigger("Forward");
            _nextInput = Time.time + 1f;
            StartCoroutine(ForwardCoroutine(transform.position + transform.forward * 3, 1));
        }
        else if (x > 0)
        {
            //_animator.SetTrigger("TurnRight");
            _nextInput = Time.time + 0.2f;
            float angle = /*GetSnapAngle*/(transform.localEulerAngles.y + 90);
            /*Quaternion finalRoration = Quaternion.AngleAxis(angle, transform.up);
            StartCoroutine(RotationCoroutine(finalRoration, 1));*/

            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
        }
        else if (x < 0)
        {
            //_animator.SetTrigger("TurnLeft");
            _nextInput = Time.time + 0.2f;
            float angle = /*GetSnapAngle*/(transform.localEulerAngles.y - 90);
            Quaternion finalRoration = Quaternion.AngleAxis(angle, transform.up);
            StartCoroutine(RotationCoroutine(finalRoration, 1));

            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
    }

    IEnumerator ForwardCoroutine(Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay - Time.deltaTime);
        transform.position = position;
    }

    IEnumerator RotationCoroutine(Quaternion rotation, float delay)
    {
        yield return new WaitForSeconds(delay - Time.deltaTime);
        Debug.Log(rotation.eulerAngles);
        transform.localRotation = rotation;
    }

    private float GetSnapAngle(float angle)
    {
        if (angle < 0)
            angle += 360;


        if (angle < 45)
            return 0;
        else if (angle < 135)
            return 90;
        else if (angle < 225)
            return 180;
        else if (angle < 315)
            return 270;
        else
            return 0;
    }
}
