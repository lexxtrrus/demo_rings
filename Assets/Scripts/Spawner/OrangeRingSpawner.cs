using UnityEngine;

public class OrangeRingSpawner : CollectableItem
{
    public override GameObject Create()
    {
        return Object.Instantiate(Resources.Load("Prefabs/OrangeRing")) as GameObject;
    }
}