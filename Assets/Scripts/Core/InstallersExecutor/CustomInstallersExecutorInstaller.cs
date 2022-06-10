using UnityEngine;
using Zenject;

namespace Core.InstallersExecutor
{
    public sealed class CustomInstallersExecutorInstaller : MonoInstaller
    {
        [SerializeField] private CustomInstallersExecutor _executor;

        public override void InstallBindings()
        {
            Container
                .Bind<ICustomInstallersExecutor>()
                .To<CustomInstallersExecutor>()
                .FromInstance(_executor)
                .AsSingle();
        }
    }
}