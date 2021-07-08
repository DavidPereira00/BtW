using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private QuestItem qi;
    private Item item;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public static ItemUI SpawnItem(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAsset.Instance.prefabItemUI, position, Quaternion.identity);
        ItemUI itemUI = transform.GetComponent<ItemUI>();
        itemUI.SetItem(item);
        

        return itemUI;
    }

    public Item GetItem()
    {
        
        return item;
       
    }
    
    public void Update()
    {
        
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
