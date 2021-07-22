using UnityEngine;

public class GreenRingSpawner : CollectableItem
{
    public override GameObject Create()
    {
        return Object.Instantiate(Resources.Load("Prefabs/GreenRing")) as GameObject;
    }
}