using UnityEngine;

namespace Core.CustomCoroutine
{
    public sealed class CustomCoroutine : MonoBehaviour
    {
        private IServiceForCustomCoroutine _service;

        public void Construct(IServiceForCustomCoroutine service)
        {
            _service = service;
        }


        public void StartCustomCoroutine(ICustomCoroutineClient customCoroutineClient)
        {
            StartCoroutine(customCoroutineClient.CoroutineForExecute());
            _service.AddFreeCoroutine(this);
        }
    }
}