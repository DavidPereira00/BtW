using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public Player player;
    public ItemType key;
    public GameObject doorTilemap;
    private bool hasKey;

    void Start()
    {
        
    }

    void Update()
    {
        if (!hasKey) {
            List<Item> currentItems = player.GetInventory().items;
            for (int i = 0; i < currentItems.Count; i++)
            {
                if (currentItems.ElementAt(i).itemType == key) {
                    doorTilemap.GetComponent<TilemapCollider2D>().enabled = false;
                    doorTilemap.GetComponent<TilemapRenderer>().enabled = false;
                    hasKey = true;
                    break;
                }
            }
        }
    }
}
