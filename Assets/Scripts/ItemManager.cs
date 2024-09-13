using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField] private ItemDataSO itemDataSO;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one ItemManager");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private List<ItemDatum> GetRandomItemsInList(List<ItemDatum> itemList, int count)
    {
        List<ItemDatum> selectedItem = new List<ItemDatum>();

        List<int> selectedIndex = new List<int>();
        while (selectedItem.Count < count)
        {
            if (selectedIndex.Count == itemList.Count)
            {
                break;
            }

            int index = Random.Range(0, itemList.Count);
            if (selectedIndex.Contains(index))
            {
                continue;
            }
            selectedIndex.Add(index);

            if (PlayerInventory.Instance.HasItem(itemList[index]))
            {
                continue;
            }
            selectedItem.Add(itemList[index]);
        }

        return selectedItem;
    }

    public List<ItemDatum> GetRandomItemsOfRairity(ItemRairity rairity, int count)
    {
        List<ItemDatum> rairityItemList = itemDataSO.GetItemsOfRairity(rairity);

        return GetRandomItemsInList(rairityItemList, count);
    }

    public List<FollowerItemDatum> GetRandomFollowerItemList(int count)
    {
        List<FollowerItemDatum> followerItemList = itemDataSO.followerItemDataList;
        List<int> selectedIndex = new List<int>();

        List<FollowerItemDatum> selectedFollowerItemList = new List<FollowerItemDatum>();

        while (selectedFollowerItemList.Count < count)
        {
            if (selectedIndex.Count == followerItemList.Count)
            {
                break;
            }

            int index = Random.Range(0, followerItemList.Count);
            if (selectedIndex.Contains(index))
            {
                continue;
            }
            selectedIndex.Add(index);

            selectedFollowerItemList.Add(followerItemList[index]);
        }

        return selectedFollowerItemList;
    }

    public List<ItemDatum> GetItemDataList()
    {
        return itemDataSO.itemDataList;
    }
}