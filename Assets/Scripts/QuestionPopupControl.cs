using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPopupControl : MonoBehaviour
{
  public Animator mainGameStateMachine;

  public void AdvanceStateMachine()
  {
    mainGameStateMachine.SetTrigger("Animation Complete");
  }

  public void RightAnswer()
  {
    mainGameStateMachine.SetTrigger("Right Answer");
  }

  public void WrongAnswer()
  {
    mainGameStateMachine.SetTrigger("Wrong Answer");
  }
}
