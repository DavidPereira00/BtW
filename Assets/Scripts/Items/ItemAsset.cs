using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public Transform prefabItemUI;

    public Sprite playerHealthPackSprite;
    public Sprite squadronHeathPackSprite;
    public Sprite waterSprite;
    public Sprite proteinBarSprite;
    public Sprite breadSprite;
    public Sprite cannedFoodSprite;
    public Sprite tuberculosisPillSprite;
    public Sprite feverPillSprite;
    public Sprite hepBPillSprite;
    public Sprite influenzaPillSprite;
    public Sprite bandagesSprite;
    public Sprite splintSprite;
    public Sprite antissepticSprite;
    public Sprite o2maskSprite;
    public Sprite blueKey;
    public Sprite greenKey;
    public Sprite yellowKey;
}
