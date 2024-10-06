using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float enemyHP = 50;
    [SerializeField] private Image enemyHPbar;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.SetDestination(MapManager.Instance.tower.position);
    }

    private void Update()
    {
        EnemyDie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Castle"))
        {
            transform.DOMove(MapManager.Instance.tower.position, 1).OnComplete(() =>
                {
                    MapManager.Instance.DamageCastle();
                    Destroy(gameObject);
                }
            );
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            DamageEnemy();
            Destroy(other.gameObject);
        }
    }

    private void DamageEnemy()
    {
        enemyHP -= 5;
        enemyHPbar.fillAmount = enemyHP / 100;
    }

    private void EnemyDie()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}