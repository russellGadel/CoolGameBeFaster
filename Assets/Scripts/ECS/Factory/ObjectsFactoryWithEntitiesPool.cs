using ECS.Components.EntityReference;
using ECS.Pool;
using UnityEngine;

namespace ECS.Factory
{
    public sealed class ObjectsFactoryWithEntitiesPool : MonoBehaviour
    {
        [SerializeField] private int _elementsAmount;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private EntitiesPool _pool;

        public void Start()
        {
            _pool.SetCapacity(_elementsAmount);

            for (int i = 0; i < _elementsAmount; i++)
            {
                GameObject elementObject = Instantiate(_prefab, _pool.transform);
                MonoEntity monoEntity = elementObject.GetComponent<MonoEntity>();
                _pool.AddElement(monoEntity);
            }
        }
    }
}