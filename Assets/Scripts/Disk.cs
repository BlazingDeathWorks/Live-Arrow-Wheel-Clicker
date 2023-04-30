using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Disk : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }
}
