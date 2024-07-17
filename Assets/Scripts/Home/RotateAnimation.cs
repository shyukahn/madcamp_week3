using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    public bool rotateClockwise = true;
    public float rotateSpeed = 0.2f;
    void Start() {
        if (rotateClockwise)
        {
            rotateSpeed *= -1;
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
