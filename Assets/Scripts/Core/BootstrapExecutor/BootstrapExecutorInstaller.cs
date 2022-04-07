﻿using UnityEngine;
using Zenject;

namespace Core.BootstrapExecutor
{
    public class BootstrapExecutorInstaller : MonoInstaller
    {
        [SerializeField] private BootstrapExecutor _executor;
        public override void InstallBindings()
        {
            Container
                .Bind<IBootstrapExecutor>()
                .To<BootstrapExecutor>()
                .FromInstance(_executor)
                .AsSingle();
        }
    }
}