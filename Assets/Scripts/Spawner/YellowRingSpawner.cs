using UnityEngine;

public class YellowRingSpawner : CollectableItem
{
    public override GameObject Create()
    {
        return Object.Instantiate(Resources.Load("Prefabs/YellowRing")) as GameObject;
    }
}