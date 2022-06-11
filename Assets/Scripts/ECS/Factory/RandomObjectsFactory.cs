using UnityEngine;

namespace ECS.Factory
{
    public class RandomObjectsFactory : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] public GameObject[] _pool;
        [SerializeField] private int _instantiateElementsAmount;


        public void Start()
        {
            for (int i = 0; i < _instantiateElementsAmount; i++)
            {
                Instantiate(GetRandomObject(), transform);
            }
        }

        private GameObject GetRandomObject()
        {
            int index = Random.Range(0, _pool.Length);
            return _pool[index];
        }
    }
}