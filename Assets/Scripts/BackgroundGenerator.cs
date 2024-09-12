using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BackgroundGenerator;

public class BackgroundGenerator : MonoBehaviour
{
    [Serializable]
    public class BackgroundData
    {
        [SerializeField] private SpriteRenderer prevSprite;
        [SerializeField] private SpriteRenderer nextSprite;
        [SerializeField] private int multiply;

        private float spriteSize;

        public void CalculateSpriteSize()
        {
            spriteSize = prevSprite.size.y;
        }

        public void UpdateBackgroundSprites(float playerHeight)
        {
            float playerHeightAmount = (playerHeight / multiply) % spriteSize;

            prevSprite.transform.position = new Vector2(0.0f, -playerHeightAmount);
            nextSprite.transform.position = new Vector2(0.0f, spriteSize - playerHeightAmount);
        }
    }

    [SerializeField] private List<BackgroundData> backgroundDataList;

    private void Awake()
    {
        foreach (BackgroundData backgroundData in backgroundDataList)
        {
            backgroundData.CalculateSpriteSize();
        }
    }

    private void Update()
    {
        foreach (BackgroundData backgroundData in backgroundDataList)
        {
            backgroundData.UpdateBackgroundSprites(PlayerHeight.Instance.GetHeight());
        }
    }
}
