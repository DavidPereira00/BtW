/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private QuestManager quests;
    private Transform questContainer;
    private Transform questSlotTemplate;

    void Awake()
    {
        questContainer = transform.Find("QuestContainer");
        questSlotTemplate = questContainer.Find("QuestSlotTemplate");
        Debug.Log(questContainer);
    }

    public void Setquests(QuestManager quests)
    {
        this.quests = quests;
        //quests.OnItemListChanged += Inventory_OnTimeListChanged;
        RefreshItems();
    }

    private void Inventory_OnTimeListChanged(object sender, System.EventArgs e)
    {
        RefreshItems();
    }

    private void RefreshItems()
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
        float itemSlotCellSize = 55f;

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
            //Debug.Log(x);
            if (x > 1)
            {
                x = 0;
                y--;
            }

        }
    }
}*/

