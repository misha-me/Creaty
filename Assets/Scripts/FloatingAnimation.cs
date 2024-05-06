using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    float originalY;

    public float floatStrength;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
        originalY + (Mathf.Sin(Time.time) * floatStrength), transform.position.z);
    }
}
