using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshPro nameText;
    private ItemDatum itemDatum;

    public void Setup(ItemDatum itemDatum)
    {
        //spriteRenderer.sprite = itemDatum.itemIcon;
        //nameText.text = itemDatum.itemName;

        this.itemDatum = itemDatum;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInventory>() != null)
        {
            PlayerInventory.Instance.GainItem(itemDatum);
        }
    }
}
