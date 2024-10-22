using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    [SerializeField] ShelfChecker[] shelfCheckers;

    [SerializeField] GameObject remoteController;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float moveSpeed;

    [SerializeField] int curProblem;
    [SerializeField] int nextProblem;


    private void Update()
    {
        if (GameManager.Instance.curProblem == curProblem)
        {
            bool answer = true;
            foreach (var checker in shelfCheckers)
            {
                answer &= checker.hasAnswerBook;
            }

            if (answer)
            {
                foreach (var checker in shelfCheckers)
                {
                    checker.OnAnswer();
                }
                GameManager.Instance.curProblem = nextProblem;
            }
        }

        if (GameManager.Instance.curProblem == nextProblem)
        {
            remoteController.SetActive(true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
