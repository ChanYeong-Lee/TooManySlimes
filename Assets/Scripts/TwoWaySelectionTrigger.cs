using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWaySelectionTrigger : MonoBehaviour
{
    [SerializeField] private List<SelectionTrigger> selectionTriggers;

    public void Setup(ItemRairity rairity)
    {
        List<ItemDatum> items = ItemManager.Instance.GetRandomItemsOfRairity(rairity, 2);

        for (int i = 0; i < items.Count; i++)
        {
            selectionTriggers[i].Setup(items[i]);
        }
    }
}