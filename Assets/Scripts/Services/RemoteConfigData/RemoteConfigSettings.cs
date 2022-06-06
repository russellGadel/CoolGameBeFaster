using UnityEngine;

namespace Services.RemoteConfigData
{
    public sealed class RemoteConfigSettings
    {
        public string CurrentEnvironmentId { get; private set; }
        public const string DevelopmentEnvironmentId = "c00befba-47a2-449f-9850-49019aa0f28f";
        public const string ProductionEnvironmentId = "45cca2e8-97fe-45f4-b4ca-c13731a51e91";

        public void SetCurrentEnvironmentId(string id)
        {
            CurrentEnvironmentId = id;
        }
    }
}