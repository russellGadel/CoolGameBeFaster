using JetBrains.Annotations;
using UnityEngine;

namespace Services.UnityAds
{
    public sealed class UnityAdsSettings : MonoBehaviour
    {
        [CanBeNull] public string GameId { get; private set; }
        [CanBeNull] public string PlacementId { get; private set; }

        public void Load()
        {
            GameId = DefinitionGameId();
            PlacementId = DefinitionPlacementId();
        }

        public bool isTestMode;

        [SerializeField] private string _androidGameId;
        [SerializeField] private string _IOSGameId;

        private string DefinitionGameId()
        {
            return Application.platform switch
            {
                RuntimePlatform.Android => _androidGameId,
                RuntimePlatform.IPhonePlayer => _IOSGameId,
                _ => _androidGameId
            };
        }

        [SerializeField] private string _androidPlacementId;
        [SerializeField] private string _IOSPlacementId;

        private string DefinitionPlacementId()
        {
            return Application.platform switch
            {
                RuntimePlatform.Android => _androidPlacementId,
                RuntimePlatform.IPhonePlayer => _IOSPlacementId,
                _ => _androidGameId
            };
        }
    }
}