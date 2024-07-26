using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime, Space.Self);
    }
}
