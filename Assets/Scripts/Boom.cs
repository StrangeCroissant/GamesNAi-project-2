using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    GameObject[] _target;
    Vector3 _targetPos;
    public ParticleSystem boomEffect;
    public GameObject _effect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("sphere"))
        {
            Explode();
        }
    }

    void Explode()
    {
        _target = GameObject.FindGameObjectsWithTag("Target");
        Vector3 _targetPos = _target[0].transform.position;

        Instantiate(_effect,_targetPos,Quaternion.identity);

      
    }
}

