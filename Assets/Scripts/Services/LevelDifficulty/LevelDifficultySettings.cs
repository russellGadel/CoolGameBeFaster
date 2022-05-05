using System;
using System.Collections.Generic;
using ECS.Components.LevelDifficultyComponent;
using UnityEngine;

namespace Services.LevelDifficulty
{
    [Serializable]
    public struct LevelDifficulty
    {
        public LevelDifficultyNaming name;
        public int spawnedPointsAmount;

        public int spawnInterferingObjectsAmountAtSameTimeMin;
        public int spawnInterferingObjectsAmountAtSameTimeMax;
        public float interferingObjectsSpawnDelayMin;
        public float interferingObjectsSpawnDelayMax;

        public int spawnedPointsAmountAtSameTimeMin;
        public int spawnedPointsAmountAtSameTimeMax;
        public float pointsSpawnDelayMin;
        public float pointsSpawnDelayMax;
        public float pointsLifeTimeMin;
        public float pointsLifeTimeMax;
    }

    public sealed class LevelDifficultySettings : MonoBehaviour
    {
        public LevelDifficulty[] settings;
    }
}