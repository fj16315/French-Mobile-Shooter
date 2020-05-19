using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanvasControl : MonoBehaviour
{
  public Animator startMenuStateMachine;

  public void StartButton()
  {
    startMenuStateMachine.SetTrigger("Starting");
  }

  public void AdvanceStateMachine()
  {
    startMenuStateMachine.SetTrigger("Animation Complete");
  }
}
