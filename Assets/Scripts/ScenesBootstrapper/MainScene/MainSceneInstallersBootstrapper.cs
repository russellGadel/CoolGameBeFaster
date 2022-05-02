using System.Collections;
using Core.BootstrapExecutor;
using Core.InstallersExecutor;
using CustomUI.AttemptToPlay;
using CustomUI.GameOverView;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class MainSceneInstallersBootstrapper : IBootstrapper
    {
        [Inject] private readonly ICustomInstallersExecutor _executor;

        public IEnumerator Execute()
        {
            AddItems();
            _executor.Execute();
            yield return new WaitWhile(() => _executor.IsDone() == false);
        }

        [Inject] private IAttemptToPlayView _attemptToPlayView;
        [Inject] private IGameOverView _gameOverView;


        private void AddItems()
        {
            _executor.Clear();

            _executor.AddInstaller(_attemptToPlayView);
            _executor.AddInstaller(_gameOverView);
        }
    }
}