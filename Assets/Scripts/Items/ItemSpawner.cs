using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item item;

    void Start()
    {
        ItemUI.SpawnItem(transform.position, item);
        Destroy(gameObject);
    }
}
