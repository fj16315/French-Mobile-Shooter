using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePopupControl : MonoBehaviour
{
  public Animator mainGameStateMachine;

  public void AdvanceStateMachine()
  {
    mainGameStateMachine.SetTrigger("Animation Complete");
  }

  public void FinishGame()
  {
    mainGameStateMachine.SetTrigger("End Game");
  }
}
