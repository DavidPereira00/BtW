using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    PlayerHealthPack,
    SquadronHealthPack,
    Water,
    ProteinBar,
    Bread,
    CannedFood,
    TuberculosisPill,
    FeverPill,
    HepBPill,
    InfluenzaPill,
    Bandages,
    Splint,
    Antisseptic,
    O2Mask,
    BlueKey,
    GreenKey,
    YellowKey
}

[Serializable]
public class Item
{
    public ItemType itemType;
    public int amount = 0;

    public Sprite GetSprite()
    {
        switch(itemType){
            case ItemType.PlayerHealthPack:
                return ItemAsset.Instance.playerHealthPackSprite;
            case ItemType.SquadronHealthPack:
                return ItemAsset.Instance.squadronHeathPackSprite;
            case ItemType.Water:
                return ItemAsset.Instance.waterSprite;
            case ItemType.ProteinBar:
                return ItemAsset.Instance.proteinBarSprite;
            case ItemType.Bread:
                return ItemAsset.Instance.breadSprite;
            case ItemType.CannedFood:
                return ItemAsset.Instance.cannedFoodSprite;
            case ItemType.TuberculosisPill:
                return ItemAsset.Instance.tuberculosisPillSprite;
            case ItemType.FeverPill:
                return ItemAsset.Instance.feverPillSprite;
            case ItemType.HepBPill:
                return ItemAsset.Instance.hepBPillSprite;
            case ItemType.InfluenzaPill:
                return ItemAsset.Instance.influenzaPillSprite;
            case ItemType.Bandages:
                return ItemAsset.Instance.bandagesSprite;
            case ItemType.Splint:
                return ItemAsset.Instance.splintSprite;
            case ItemType.Antisseptic:
                return ItemAsset.Instance.antissepticSprite;
            case ItemType.BlueKey:
                return ItemAsset.Instance.blueKey;
            case ItemType.GreenKey:
                return ItemAsset.Instance.greenKey;
            case ItemType.YellowKey:
                return ItemAsset.Instance.yellowKey;
            default:
                return ItemAsset.Instance.o2maskSprite;
        }
    }
}
