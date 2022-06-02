using UnityEngine;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameSettings : MonoBehaviour
    {
        public string AppUrlAtStore { get; private set; }

        public void Construct()
        {
            AppUrlAtStore = DefinitionAppUrl();
        }


        [SerializeField] private string _appUrlAtPlayMarket;
        [SerializeField] private string _appUrlAtIOSMarket;

        private string DefinitionAppUrl()
        {
            return Application.platform switch
            {
                RuntimePlatform.Android => _appUrlAtPlayMarket,
                RuntimePlatform.IPhonePlayer => _appUrlAtIOSMarket,
                _ => _appUrlAtPlayMarket
            };
        }
    }
}