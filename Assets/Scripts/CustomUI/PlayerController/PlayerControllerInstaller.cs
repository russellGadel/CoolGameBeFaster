using CustomUI.PlayerController.Mobile;
using CustomUI.PlayerController.PC;
using UnityEngine;
using Zenject;

namespace CustomUI.PlayerController
{
    public sealed class PlayerControllerInstaller :
        MonoInstaller
    {
        public override void InstallBindings()
        {
           /* if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer)
            {
                InstallPCPresenter();
            }
            else
            {
                InstallMobilePresenter();
            }*/
           InstallMobilePresenter();
        }


        [SerializeField] private PlayerControllerMobileView mobileView;
        [SerializeField] private PlayerControllerMobileSettings mobileSettings;

        private void InstallMobilePresenter()
        {
            mobileView.Construct(in mobileSettings);
            BindMobilePresenter();
        }

        private void BindMobilePresenter()
        {
            Container
                .Bind<IPlayerControllerPresenter>()
                .FromInstance(new PlayerControllerMobilePresenter(mobileView))
                .AsSingle();
        }

        private void InstallPCPresenter()
        {
            Container
                .Bind<IPlayerControllerPresenter>()
                .FromInstance(new PlayerControllerPCPresenter())
                .AsSingle();
        }
    }
}