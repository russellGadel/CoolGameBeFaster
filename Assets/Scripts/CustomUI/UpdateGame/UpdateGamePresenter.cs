using System;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGamePresenter : IUpdateGamePresenter
    {
        private readonly IUpdateGameView _view;
        private readonly IUpdateGameModel _model;

        public UpdateGamePresenter(IUpdateGameView view, IUpdateGameModel model)
        {
            _view = view;
            _model = model;
        }

        public void OpenView()
        {
            _view.Open();
        }

        public void CloseView()
        {
            _view.Close();
        }

        public void AddObserverToUpdateButton(Action observer)
        {
            _view.AddObserverToPressUpdateButtonEvent(observer);
        }

        public void GoToAppStore()
        {
            _model.GoToAppStore();
        }
    }
}