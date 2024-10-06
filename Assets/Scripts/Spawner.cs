using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn),0,Random.Range(0,3f));
    }

    private void Spawn() //object pooling should add for opt.
    {
        Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }
}