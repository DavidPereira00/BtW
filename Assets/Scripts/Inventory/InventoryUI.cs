using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnTimeListChanged;
        RefreshItems();
    }

    private void Inventory_OnTimeListChanged(object sender, System.EventArgs e)
    {
        RefreshItems();
    }

    public  void RefreshItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate)
            {
                continue;
            }

            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 70f;

        foreach (Item item in inventory.GetItems())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("ItemSlotImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI itemAmountText = itemSlotRectTransform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();
            itemAmountText.SetText(item.amount.ToString());

            x++;
            if (x > 2)
            {
                x = 0;
                y--;
            }

        }
    }
}
