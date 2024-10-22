using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfChecker : MonoBehaviour
{
    public bool hasAnswerBook;
    public Transform answerBook;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == answerBook)
        {
            hasAnswerBook = true;
            print(collision.transform.name);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform == answerBook)
        {
            hasAnswerBook = false;
        }
    }

    public void OnAnswer()
    {
        answerBook.parent = transform;
    }
}
