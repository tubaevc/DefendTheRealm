using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
   public static MapManager Instance;
   [SerializeField] public List<Transform> controlPoints = new List<Transform>();
   [SerializeField] public Transform tower;
   private float castleHP = 100;
   [SerializeField] private Image hpBar;
   private void Awake()
   {
      Instance = this;
   }

   public void DamageCastle()
   {
      castleHP -= 5;
      hpBar.fillAmount = castleHP / 100;
   }
}
