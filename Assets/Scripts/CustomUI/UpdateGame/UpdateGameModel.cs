using UnityEngine;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameModel : IUpdateGameModel
    {
        private readonly UpdateGameSettings _settings;

        public UpdateGameModel(UpdateGameSettings settings)
        {
            _settings = settings;
        }

        public void GoToAppStore()
        {
            Application.OpenURL(_settings.AppUrlAtStore);
        }
    }
}