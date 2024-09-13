using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerController : MonoBehaviour
{
    public static PlayerFollowerController Instance { get; private set; }

    [SerializeField] private List<PlayerFollowerTransform> followerTransformList;

    private void Awake()
    {
        Instance = this;
    }

    private void SetFollowerAtIndex(int index, GameObject playerFollwer, out GameObject prevFollower)
    {
        if (index > followerTransformList.Count)
        {
            prevFollower = null;
            return;
        }

        prevFollower = followerTransformList[index].GetPlayerFollower();
        followerTransformList[index].SetPlayerFollower(playerFollwer);
    }

    public void AddFollower(GameObject playerFollower)
    {
        for (int i = 0; i < followerTransformList.Count; i++)
        {
            if (followerTransformList[i].GetPlayerFollower() == null)
            {
                followerTransformList[i].SetPlayerFollower(playerFollower);
                return;
            }
        }
    }

    public void RemoveFollowerAtIndex(int index)
    {

    }

    public void SwitchFollowers(int leftHand, int rightHand)
    {
        if (leftHand > followerTransformList.Count || rightHand > followerTransformList.Count)
        {
            return;
        }

        GameObject leftHandPlayerFollower = followerTransformList[leftHand].GetPlayerFollower();

        SetFollowerAtIndex(rightHand, leftHandPlayerFollower, out GameObject rightHandPlayerFollower);
        SetFollowerAtIndex(leftHand, rightHandPlayerFollower, out GameObject prevLeftHandPlayerFollower);
    }
}
