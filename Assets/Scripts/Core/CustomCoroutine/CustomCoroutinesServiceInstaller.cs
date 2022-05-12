using UnityEngine;
using Zenject;

namespace Core.CustomCoroutine
{
    public sealed class CustomCoroutinesServiceInstaller : MonoInstaller
    {
        [SerializeField] private CustomCoroutinesService _service;

        public override void InstallBindings()
        {
            Container
                .Bind<ICustomCoroutinesService>()
                .FromInstance(_service)
                .AsSingle();
        }
    }
}