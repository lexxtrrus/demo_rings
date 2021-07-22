using System;
using UnityEngine;

namespace Movement
{
    public class InputController: MonoBehaviour
    {
        private Camera mainCamera;
        public static Action<Vector3> OnDestinationPointChange;
        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;

            var tapPostion = Input.mousePosition;
            var worldPostion = mainCamera.ScreenToWorldPoint(tapPostion);
            worldPostion.z = 0f;
            OnDestinationPointChange?.Invoke(worldPostion);
        }
    }
}