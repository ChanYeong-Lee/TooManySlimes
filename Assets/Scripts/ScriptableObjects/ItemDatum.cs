using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Follower,
}

public enum ItemRairity
{
    Normal,
    Rair,
    Unique,
}

[Serializable]
public class ItemDatum
{
    public string itemName;
    public ItemRairity itemRairity;
    public Sprite itemIcon;
    public string Description;
    public BaseItem itemPrefab;

    public virtual int GetCost(bool isSell)
    {
        int cost = 0;
        switch (itemRairity)
        {
            case ItemRairity.Normal:
                cost = isSell ? 3 : 5;
                break;
            case ItemRairity.Rair:
                cost = isSell ? 6 : 10;
                break;
            case ItemRairity.Unique:
                cost = isSell ? 9 : 15;
                break;
        }

        return cost;
    }
}