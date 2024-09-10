using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Serializable]
    public class BackgroundData
    {
        public SpriteRenderer prevSprite;
        public SpriteRenderer nextSprite;
        public int multiply;
    }

    [SerializeField] private List<BackgroundData> backgroundDataList;
    [SerializeField] private PlayerHeight playerHeight;

    private void Update()
    {
        if (playerHeight == null)
        {
            return;
        }

        foreach (BackgroundData backgroundData in backgroundDataList)
        {
            float playerHeightAmount = (playerHeight.GetHeight() % backgroundData.prevSprite.size.y) / backgroundData.multiply;
            print(playerHeightAmount);
            backgroundData.prevSprite.transform.position = new Vector2(0.0f, -playerHeightAmount);
            backgroundData.nextSprite.transform.position = new Vector2(0.0f, backgroundData.prevSprite.size.y - playerHeightAmount);
        }
    }
}
