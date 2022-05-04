﻿using System;
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
        
        public int spawnInterferingObjectsAmountAtSameTime;
        public float interferingObjectsSpawnDelay;

        public int spawnedPointsAmountAtSameTime;
        public float pointsSpawnDelay;
        public float pointsLifeTimeMin;
        public float pointsLifeTimeMax;

    }

    public sealed class LevelDifficultySettings : MonoBehaviour
    {
        public LevelDifficulty[] settings;

        /*  public Dictionary<double, LevelDifficulty> Settings { get; private set; } =
              new Dictionary<double, LevelDifficulty>();
  
          public void Construct()
          {
              Settings.Clear();
              
              for (int i = 0; i < _setSettings.Length; i++)
              {
                  Settings.Add(_setSettings[i].spawnedPointsAmount, _setSettings[i]);
              }
          }*/
    }
}