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

  public void Answer(ButtonData data)
  {
    if (data.isCorrect)
    {
      mainGameStateMachine.SetTrigger("Right Answer");
    }
    else
    {
      mainGameStateMachine.SetTrigger("Wrong Answer");
    }
  }
}
