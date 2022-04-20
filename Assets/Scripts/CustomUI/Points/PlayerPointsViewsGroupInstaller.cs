using System;
using UnityEngine;
using Zenject;

namespace CustomUI.Points
{
    public sealed class PlayerPointsViewsGroupInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPointsViewsGroup _viewsGroup;

        public override void InstallBindings()
        {
            BindViewsGroup();
        }

        private void BindViewsGroup()
        {
            Container
                .Bind<IPlayerPointsViewsGroup>()
                .FromInstance(_viewsGroup)
                .AsSingle();
        }
    }
}