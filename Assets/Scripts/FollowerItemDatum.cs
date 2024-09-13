using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FollowerItemDatum : ItemDatum
{
    public int level;

    public override int GetCost(bool isSell)
    {
        int cost = 0;
        switch (level)
        {
            case 1:
                cost = isSell ? 3 : 5;
                break;
            case 2:
                cost = isSell ? 6 : 10;
                break;
            case 3:
                cost = isSell ? 12 : 20;
                break;
        }

        return cost;
    }
}