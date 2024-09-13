using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public event EventHandler OnCoinUpdate;
    public event EventHandler OnItemGain;
    public event EventHandler OnFollowerItemUpdate;

    private int coin;
    private Dictionary<string, bool> itemInventory;
    private List<ItemDatum> itemList;
    private List<FollowerItemDatum> followerItemInventory;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one PlayerInventory");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        InitiateItemInventory();
    }

    private void InitiateItemInventory()
    {
        itemInventory = new Dictionary<string, bool>();
        itemList = new List<ItemDatum>();
        followerItemInventory = new List<FollowerItemDatum>();

        foreach (ItemDatum itemDatum in ItemManager.Instance.GetItemDataList())
        {
            itemInventory[itemDatum.itemName] = false;
        }
    }

    public bool HasItem(ItemDatum itemDatum)
    {
        return itemInventory[itemDatum.itemName];
    }

    public List<FollowerItemDatum> GetFollowerItemList()
    {
        return followerItemInventory;
    }

    public void GainFollowerItem(FollowerItemDatum followerItemDatum)
    {
        followerItemInventory.Add(followerItemDatum);
        OnFollowerItemUpdate?.Invoke(this, EventArgs.Empty);
    }

    public void LostFollwerItem(FollowerItemDatum followerItemDatum)
    {
        if (followerItemInventory.Contains(followerItemDatum))
        {
            followerItemInventory.Remove(followerItemDatum);
        }
        OnFollowerItemUpdate?.Invoke(this, EventArgs.Empty);
    }

    public void GainCoin(int amount)
    {
        coin += amount;
        OnCoinUpdate?.Invoke(this, EventArgs.Empty);
    }
 
    public int GetCoin()
    {
        return coin;
    }

    public void SpendCoin(int amount)
    {
        coin -= amount;
        OnCoinUpdate?.Invoke(this, EventArgs.Empty);
    }

    public void GainItem(ItemDatum itemDatum)
    {
        OnItemGain?.Invoke(this, EventArgs.Empty);

        itemDatum.itemPrefab.GainItem();
        itemList.Add(itemDatum);
        itemInventory[itemDatum.itemName] = true;
    }
}