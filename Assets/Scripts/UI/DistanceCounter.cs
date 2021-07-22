using Movement;
using SaveLoad;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DistanceCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textDistance;
        private const string Distance = "Distance";
        private float totalDistance;
        private float textDistanceValue;
        private bool isValueChanged;
        private void Awake()
        {
            totalDistance = Profile.TotalDistance;
            textDistanceValue = Mathf.FloorToInt(totalDistance);
            textDistance.text = $"{Distance}: {textDistanceValue.ToString()}";

            CharacterMovement.OnDistanceValueChanged += OnDistanceValueChange;
        }

        private void OnDestroy()
        {
            CharacterMovement.OnDistanceValueChanged -= OnDistanceValueChange;
        }

        private void OnDistanceValueChange(float difference)
        {
            totalDistance += difference;
            var value = Mathf.FloorToInt(totalDistance);
            if (value > textDistanceValue)
            {
                textDistanceValue = value;
                textDistance.text = $"{Distance}: {textDistanceValue.ToString()}";
                Profile.TotalDistance = value;
            }
        }
    }
}
