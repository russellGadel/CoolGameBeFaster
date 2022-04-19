using ECS.Components.EntityReference;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitializeEntityReferenceSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InitializeEntityMonoRequest> _filter = null;

        public void Init()
        {
            foreach (var idx in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(idx);
                ref InitializeEntityMonoRequest monoRequest = ref _filter.Get1(idx);

                monoRequest.monoEntityRef.Entity = entity;
                entity.Del<InitializeEntityMonoRequest>();
            }
        }
    }
}