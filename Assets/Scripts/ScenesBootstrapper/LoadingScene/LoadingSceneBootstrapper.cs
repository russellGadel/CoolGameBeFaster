using Core.EventsLoader;
using CustomEvents;
using ScenesLoader;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapper : ISceneBootstrapper
    {
        [Inject] private readonly LoadingWindowDualEvents _loadingWindowDualEvents;
        [Inject] private readonly ICustomEventsLoader _loader;
        [Inject] private readonly ICustomScenesLoader _scenesLoader;

        public void Enter()
        {
            _loadingWindowDualEvents.Execute();
            
            AddEnterItems();
            _loader.Load();
        }

        public void Exit()
        {
            _loadingWindowDualEvents.Undo();
        }

        [Inject] private readonly LoadSavedDataEvent _loadSavedDataEvent;
        [Inject] private readonly SetGameTypeEvent _setGameTypeEvent;
        [Inject] private readonly RemoteConfigDataEvents _remoteConfigDataEvents;
        [Inject] private readonly UpdateGameWindowEvents _updateGameWindowEvents;
        [Inject] private readonly SaveDataEvent _saveDataEvent;
        [Inject] private readonly PrivacyPolicyWindowEvents _privacyPolicyWindowEvents;

        private void AddEnterItems()
        {
            _loader.Clear();

            // boot order hard
            // start
            _loader.AddEvent(_loadSavedDataEvent);
            _loader.AddEvent(_setGameTypeEvent);
            _loader.AddEvent(_remoteConfigDataEvents);
            //
            _loader.AddEvent(_updateGameWindowEvents);
            //
            _loader.AddEvent(_privacyPolicyWindowEvents);
            // start part end

            // end
            _loader.AddEvent(_saveDataEvent);

            _loader.AddEvent(new LoadMainSceneEvent(_scenesLoader, this));
        }
    }
}