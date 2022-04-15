using System;
using ECS.Components.Entity;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class EnterToInactiveZoneTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
       {
           Debug.Log("Enter to inactive Zone");
           EntityMono entityMono = col.gameObject.GetComponent<EntityMono>();
           entityMono.Entity.Replace(new DeactivateObjectEvent());
       }
    }
}