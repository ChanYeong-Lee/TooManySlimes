using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follwer : MonoBehaviour
{
    public enum FollowType
    {
        Fixed,
        Lerp,
        SmoothDamp,
    }

    [SerializeField] private Transform followTarget;
    [SerializeField] private FollowType followType;
    [SerializeField] private float followSpeed;

    private Vector3 smoothVelocity;

    private void Update()
    {
        if (followTarget == null)
        {
            return;
        }

        switch (followType)
        {
            case FollowType.Fixed:
                transform.position = followTarget.position;
                break;
            case FollowType.Lerp:
                transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
                break;
            case FollowType.SmoothDamp:
                transform.position = Vector3.SmoothDamp(transform.position, followTarget.position, ref smoothVelocity, followSpeed);
                break;
        }
    }

    public void SetFollowType(FollowType followType)
    {
        this.followType = followType;
    }

    public void SetFollowTarget(Transform target)
    {
        this.followTarget = target;
    }
}
