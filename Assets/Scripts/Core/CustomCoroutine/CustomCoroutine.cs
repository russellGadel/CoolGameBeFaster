using UnityEngine;

namespace Core.CustomCoroutine
{
    public sealed class CustomCoroutine : MonoBehaviour
    {
        private IServiceForCustomCoroutine _service;

        public void Construct(in IServiceForCustomCoroutine service)
        {
            _service = service;
        }


        public void StartCustomCoroutine(in ICustomCoroutineClient customCoroutineClient)
        {
            StartCoroutine(customCoroutineClient.CoroutineForExecute());
            _service.AddFreeCoroutine(this);
        }
    }
}