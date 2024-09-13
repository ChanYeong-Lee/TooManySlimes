using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "New Item Data")]
public class ItemDataSO : ScriptableObject
{
    public List<ItemDatum> itemDataList;
    public List<FollowerItemDatum> followerItemDataList;

    public List<ItemDatum> GetItemsOfRairity(ItemRairity rairity)
    {
        List<ItemDatum> itemList = new List<ItemDatum>();

        foreach (ItemDatum item in itemDataList)
        {
            if (item.itemRairity == rairity)
            {
                itemList.Add(item);
            }
        }

        return itemList;
    }
}
