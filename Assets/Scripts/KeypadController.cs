using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] string answer;
    [SerializeField] int curProblem;
    [SerializeField] int nextProblem;

    public void InputEnter()
    {
        if (curProblem == GameManager.Instance.curProblem &&
            input != null &&
            input.text.Equals(answer))
        {
            GameManager.Instance.curProblem = nextProblem;
            print($"문제 {curProblem} 정답");
        }
    }
}
