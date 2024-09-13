using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerTransform : MonoBehaviour
{
    private GameObject playerFollower;

    public void SetPlayerFollower(GameObject playerFollower)
    {
        if (this.playerFollower != null)
        {
            this.playerFollower.transform.parent = null;
        }

        this.playerFollower = playerFollower;
        playerFollower.transform.parent = transform;
        playerFollower.transform.localPosition = Vector3.zero;
    }

    public void DestroyPlayerFollower()
    {
        if (playerFollower != null)
        {
            Destroy(playerFollower.gameObject);
        }

        playerFollower = null;
    }

    public GameObject GetPlayerFollower()
    {
        return playerFollower;
    }
}
