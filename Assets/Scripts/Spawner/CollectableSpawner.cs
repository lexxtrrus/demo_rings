using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    CollectableSpawner()
    {
        collectableItems = new List<CollectableItem>()
        {
            new GreenRingSpawner(),
            new OrangeRingSpawner(),
            new YellowRingSpawner()
        };
    }

    private List<CollectableItem> collectableItems; 

    private float width;
    private float height;
    private Camera mainCamera;
    
    private void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        mainCamera = Camera.main;

        InvokeRepeating(nameof(InstatiateCollectableItem), 1f, Random.Range(3f, 5f)); 
    }

    private void InstatiateCollectableItem()
    { 
        var item = collectableItems[UnityEngine.Random.Range(0, collectableItems.Count)].Create();
        var randomPosition = GetRandomPostion();
        item.transform.position = randomPosition;
    }

    private Vector3 GetRandomPostion()
    {
        var x = UnityEngine.Random.Range(0, width);
        var y = UnityEngine.Random.Range(0, height);
        Vector3 screenPos = new Vector3(x, y, 0f);
        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(screenPos);
        spawnPosition.z = 0f;
        return spawnPosition;
    }
}