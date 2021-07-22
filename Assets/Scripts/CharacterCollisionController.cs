using System;
using UnityEngine;

public class CharacterCollisionController: MonoBehaviour
{
    public static Action OnPointsValueChanged;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnPointsValueChanged?.Invoke();
    }
}