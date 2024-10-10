using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
   [SerializeField] private int damage;
   [SerializeField] private float speed;

   private Character target;
   
   private UnityAction hitCallback;

   public void Initialize(Character projectileTarget, UnityAction onHitCallback)
   {
      target = projectileTarget;
      hitCallback = onHitCallback;
   }
}
