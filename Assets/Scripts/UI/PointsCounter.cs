using Movement;
using SaveLoad;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textpoints;
        private const string Points = "Points";
        private int points;
        private void Awake()
        {
            points = Profile.Points;
            textpoints.text = $"{Points}: {points.ToString()}";

            CharacterCollisionController.OnPointsValueChanged += OnPointsValueChange;
        }

        private void OnDestroy()
        {
            CharacterCollisionController.OnPointsValueChanged -= OnPointsValueChange;
        }

        private void OnPointsValueChange()
        {
            points++;
            textpoints.text = $"{Points}: {points.ToString()}";
            Profile.Points = points;
        }
    }
}