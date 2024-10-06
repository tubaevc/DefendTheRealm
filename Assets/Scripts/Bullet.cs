using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            transform.forward = dir;
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}