using UnityEngine;
using Zenject;

namespace Services.InterferingObjectsService
{
    public sealed class InterferingObjectsServiceInstaller : MonoInstaller
    {
        [SerializeField] private InterferingObjectsService _service;

        public override void InstallBindings()
        {
            Container
                .Bind<IInterferingObjectsService>()
                .FromInstance(_service)
                .AsSingle();
        }
    }
}