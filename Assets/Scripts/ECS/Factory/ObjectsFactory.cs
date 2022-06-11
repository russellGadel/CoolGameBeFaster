using UnityEngine;

namespace ECS.Factory
{
    public class ObjectsFactory : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _elementsAmount;

        public void Start()
        {
            for (int i = 0; i < _elementsAmount; i++)
            {
                Instantiate(_prefab, transform);
            }
        }
    }
}