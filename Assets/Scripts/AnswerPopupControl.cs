using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPopupControl : MonoBehaviour
{
  public Animator mainGameStateMachine;

  public void AdvanceStateMachine()
  {
    mainGameStateMachine.SetTrigger("Animation Complete");
  }

  public void AnswerResponse()
  {
    mainGameStateMachine.SetTrigger("Fade Answer Out");
  }
}
