using UnityEngine;

namespace Services.RemoteConfigData
{
    public sealed class RemoteConfigSettings : MonoBehaviour
    {
        public string CurrentEnvironmentId { get; private set; }

        [SerializeField] private string _developmentEnvironmentId;
        public string DevelopmentEnvironmentId => _developmentEnvironmentId;

        [SerializeField] private string _productionEnvironmentId;
        public string ProductionEnvironmentId => _productionEnvironmentId;


        public void SetCurrentEnvironmentId(in string id)
        {
            CurrentEnvironmentId = id;
        }
    }
}