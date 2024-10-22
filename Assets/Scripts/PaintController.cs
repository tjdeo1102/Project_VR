using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintController : MonoBehaviour
{
    [SerializeField] Vector3[] holdLocalPos;
    [SerializeField] Vector3[] holdLocalScale;
    [SerializeField] Transform[] frames;
    [SerializeField] Transform[] answers;
    [SerializeField] int curProblem;
    [SerializeField] int nextProblem;

    [SerializeField] float minPlaceDistance;
    [SerializeField] Vector3 holdRotation;
    public void PlacePaintCheck(Transform paint)
    {
        if (paint.CompareTag("Paint") == false) return;
        var closedFrameIdx = -1;
        var closedDistance = float.MaxValue;
        for (int i = 0; i < frames.Length; i++)
        {
            var dis = Vector3.Distance(paint.position, frames[i].position);

            if (dis < closedDistance && dis < minPlaceDistance)
            {
                closedDistance = dis;
                closedFrameIdx = i;
            }
        }

        if (closedFrameIdx > -1)
        {
            paint.parent = frames[closedFrameIdx];
            if (frames[closedFrameIdx].childCount > 1)
            {
                paint.parent = null;
                return;
            }
            paint.localPosition = holdLocalPos[closedFrameIdx];
            paint.localScale = holdLocalScale[closedFrameIdx];
            paint.localRotation = Quaternion.Euler(holdRotation);

            if(GameManager.Instance.curProblem == curProblem) PaintCheck();
        }
        else
        {
            print("그림 놓기 오류");
        }
    }


    void PaintCheck()
    {
        if (frames.Length != answers.Length) return;
        var answer = true;
        for (int i = 0; i < frames.Length; i++)
        {
            if (frames[i].childCount > 0 &&
                frames[i].GetChild(0) == answers[i])
            {
                answer &= true;
            }
        }

        if (answer)
        {
            GameManager.Instance.curProblem = nextProblem;
            print($"문제 {curProblem} 정답");
        }
    }
}
