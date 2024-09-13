using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject follower1;
    public GameObject follower2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerFollowerController.Instance.AddFollower(PoolManager.Instance.Spawn(follower1, transform.position, Quaternion.identity));
        }
    }
}
