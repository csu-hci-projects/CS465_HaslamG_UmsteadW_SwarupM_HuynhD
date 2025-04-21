using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR;

public class ThumbsUpGesture : MonoBehaviour
{
    public XRHandSubsystem handSubsystem;
    public GameObject messageDisplayPrefab;


    void Update()
    {
        if (handSubsystem == null) return;
    }

    private void CheckThumbsUp(XRHand hand, string handName)
    {
        if (!hand.isTracked) return;

        var thumbTip = hand.GetJoint(XRHandJointID.ThumbTip);
        var indexTip = hand.GetJoint(XRHandJointID.IndexTip);
        var middleTip = hand.GetJoint(XRHandJointID.MiddleTip);

        if (thumbTip.TryGetPose(out Pose thumbPose) &&
            indexTip.TryGetPose(out Pose indexPose) &&
            middleTip.TryGetPose(out Pose middlePose))
        {
            float thumbIndexDist = Vector3.Distance(thumbPose.position, indexPose.position);
            float thumbMiddleDist = Vector3.Distance(thumbPose.position, middlePose.position);

            if (thumbIndexDist > .07f && thumbMiddleDist > .07f)
            {
                Debug.Log($"{handName} hand thumbs up!");
            }
        }

    }
}
