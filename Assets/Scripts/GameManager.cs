using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject inventoryUI;
    public GameObject shopUI;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StageManager.Instance.StartStage();
    }

    public void ResumeGame()
    {
        inventoryUI.SetActive(false);
        shopUI.SetActive(false);
        StageManager.Instance.StartStage();
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        StageManager.Instance.PauseGame();
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);
        StageManager.Instance.PauseGame();
    }
}
