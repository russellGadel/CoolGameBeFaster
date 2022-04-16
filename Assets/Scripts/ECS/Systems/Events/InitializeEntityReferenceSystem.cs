using ECS.Components.EntityReference;
using Leopotam.Ecs;
using UnityEngine.WSA;

namespace ECS.Systems.Events
{
    public class InitializeEntityReferenceSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> _filter = null;

        public void Init()
        {
            foreach (var idx in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(idx);
                ref InitializeEntityRequest request = ref _filter.Get1(idx);

                request.entityRef.Entity = entity;
                entity.Del<InitializeEntityRequest>();
            }
        }
    }
}