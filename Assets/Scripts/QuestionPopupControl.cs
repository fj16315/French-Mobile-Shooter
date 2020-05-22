using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPopupControl : MonoBehaviour
{
  public Animator mainGameStateMachine;
  public bool isUsable;

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

  private void LateUpdate()
  {
    if (!isUsable)
    {
      GetComponent<CanvasGroup>().interactable = false;
      GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
  }
}
