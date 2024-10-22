using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] Transform[] children;

    [SerializeField] Vector3[] targetPositions;
    [SerializeField] float moveSpeed;
    int curTargetIdx;

    [SerializeField] int curProblem;
    [SerializeField] int nextProblem;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.curProblem == curProblem)
        {
            foreach (Transform t in children)
            {
                t.parent = transform;
            }
            if (curTargetIdx < targetPositions.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositions[curTargetIdx], moveSpeed * Time.deltaTime);

                // 도착하면 목표 위치 갱신
                if (Vector3.Distance(transform.position, targetPositions[curTargetIdx]) < 0.01f)
                {
                    curTargetIdx++;
                }
            }
        }
    }
}
