using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   [SerializeField] private float fireRate;
   [SerializeField] private float attackRadius;
   [SerializeField] private Bullet bulletPrefab;
   private Collider[] enemies;
   private EnemyController currentEnemy = null;
   private void Start()
   {
      InvokeRepeating(nameof(ScanArea),0,fireRate);
   }

   private void OnDrawGizmos()
   {
      Gizmos.color=Color.green;
      Gizmos.DrawWireSphere(transform.position,attackRadius);
   }

   private void ScanArea()
   {
      float distance = 1000;
      enemies = Physics.OverlapSphere(transform.position, attackRadius);
      foreach ( Collider enemy in enemies )
      {
         if (enemy.gameObject.TryGetComponent(out EnemyController enemyController)) // collider's object has enemycontroller script
         {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist <= distance)
            {
               currentEnemy = enemyController;
               distance = dist; // if it is smaller this is enemy
            }
         }
      }

      if (currentEnemy)
      {
         Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
         bullet.SetTarget(currentEnemy.transform);
      }
   }
   

   private void Update()
   {
      if (currentEnemy)
      {
         Vector3 dir = currentEnemy.transform.position - transform.position;
         dir.y = 0;
         transform.rotation = Quaternion.LookRotation(dir);
      }
   }
}
