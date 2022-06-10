using UnityEngine;
using Zenject;

namespace Core.CustomInvoker
{
    public sealed class CustomInvokerServiceInstaller : MonoInstaller
    {
        [SerializeField] private CustomInvokerService _service;

        public override void InstallBindings()
        {
            Container
                .Bind<ICustomInvokerService>()
                .FromInstance(_service)
                .AsSingle();
        }
    }
}