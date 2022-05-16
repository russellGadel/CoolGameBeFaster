using Core.EventsLoader;
using ScenesBootstrapper.LoadingScene.Events;
using ScenesBootstrapper.MainScene.Events;
using ScenesLoader;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapper : ISceneBootstrapper
    {
        [Inject] private readonly LoadingWindowEvents _loadingWindowEvents;
        [Inject] private readonly ICustomEventsLoader _loader;
        [Inject] private readonly ICustomScenesLoader _scenesLoader;

        public void Enter()
        {
            _loadingWindowEvents.Execute();

            Debug.Log("LoadingScene Enter");

            AddEnterItems();
            _loader.Load();
        }

        public void Exit()
        {
            _loadingWindowEvents.Undo();
        }

        [Inject] private readonly LoadSavedDataEvent _loadSavedDataEvent;
        [Inject] private readonly SaveDataEvent _saveDataEvent;
        [Inject] private readonly PrivacyPolicyWindowEvent _privacyPolicyWindowEvent;

        private void AddEnterItems()
        {
            _loader.Clear();
            _loader.AddEvent(_loadSavedDataEvent);
            _loader.AddEvent(_privacyPolicyWindowEvent);

            _loader.AddEvent(_saveDataEvent);

            _loader.AddEvent(new LoadMainSceneEventLoader(_scenesLoader, this));
        }
    }
}