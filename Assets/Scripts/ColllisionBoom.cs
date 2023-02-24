using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllisionBoom : MonoBehaviour
{
    public Transform collisionPoint;
    public GameObject boomEffect;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(boomEffect, collisionPoint.position, collisionPoint.rotation);
    }
}
