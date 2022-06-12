using System;
using System.Collections.Generic;
using ECS.Components.EntityReference;
using ECS.Components.LevelDifficulty;
using ECS.Pool;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.InterferingObjectsService
{
    [Serializable]
    public struct InterferingObjectsPoolsByDifficulty
    {
        public LevelDifficultyNaming difficulty;
        public List<EntitiesPool> pool;
    }

    public sealed class InterferingObjectsService : MonoBehaviour
        , IInterferingObjectsService
    {
        [Header("Difficulties must be at sequence 1,2,3 ...")] [SerializeField]
        private List<InterferingObjectsPoolsByDifficulty> _interferingObjectsPools;

        [CanBeNull]
        public MonoEntity GetInterferingObject(in LevelDifficultyNaming currentLevelDifficulty)
        {
            List<EntitiesPool> pool = _interferingObjectsPools[(int) currentLevelDifficulty].pool;

            int poolIndex = 0;

            if (pool.Count == 0)
            {
                Debug.Log("return null from Service");
                return null;
            }
            else if (pool.Count > 1)
            {
                poolIndex = Random.Range(0, pool.Count);
            }

            Debug.Log("return element from Service");

            return pool[poolIndex].GetNextElement();
        }
    }
}