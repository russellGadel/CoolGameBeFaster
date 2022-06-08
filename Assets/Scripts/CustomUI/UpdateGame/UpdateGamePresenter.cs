using UnityEngine.Events;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGamePresenter : IUpdateGamePresenter
    {
        private readonly IUpdateGameView _view;
        private readonly IUpdateGameModel _model;

        public UpdateGamePresenter(in IUpdateGameView view, in IUpdateGameModel model)
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


        public void SubscribeToUpdateButton(UnityAction observer)
        {
            _view.SubscribeToPressUpdateButton(observer);
        }

        public void UnsubscribeFromPressUpdateButton(UnityAction observer)
        {
            _view.UnsubscribeFromPressUpdateButton(observer);
        }


        public void GoToAppStore()
        {
            _model.GoToAppStore();
        }
    }
}