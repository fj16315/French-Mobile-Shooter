using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPopupControl : MonoBehaviour
{
  public Animator mainGameStateMachine;

  public void AdvanceStateMachine()
  {
    mainGameStateMachine.SetTrigger("Animation Complete");
  }

  public void IntroButton()
  {
    mainGameStateMachine.SetTrigger("Fade Intro Out");
  }
}
