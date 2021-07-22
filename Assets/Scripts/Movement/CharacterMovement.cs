using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Movement
{
    public class CharacterMovement : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private float speed = 5f;
        private Vector3 to;
        private Coroutine coroutine;
        private bool isPointerDown = false;

        public static Action<float> OnDistanceValueChanged;
        private void Start()
        {
            InputController.OnDestinationPointChange += SetDestination;
        }

        private void OnDestroy()
        {
            InputController.OnDestinationPointChange -= SetDestination;
        }

        private void SetDestination(Vector3 destination)
        {
            if(isPointerDown) return;

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(MoveCharacter(destination));
        }

        private IEnumerator MoveCharacter(Vector3 destination)
        {
            to = destination;
            while (Vector3.Distance(transform.position,to) > 0.01f)
            {
                var previousPosition = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, to, speed * Time.deltaTime);
                float distance = Vector3.Distance(transform.position, previousPosition);
                
                OnDistanceValueChanged?.Invoke(distance);

                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, (to - transform.position));
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
                
                yield return null;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StopCoroutine(coroutine);
            StartCoroutine(PointerStopInput());
        }

        private IEnumerator PointerStopInput()
        {
            isPointerDown = true;
            yield return null;
            isPointerDown = false;
        }
    }
}