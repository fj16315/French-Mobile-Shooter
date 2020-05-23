using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public float duration;
  public Text display;
  private Animator mainGameStateMachine;
  private bool hasTimedOut;
  public bool startTimer;

  private void Start()
  {
    display.text = string.Format("Time Remaining: {0} seconds", duration.ToString("F2"));
    mainGameStateMachine = GetComponent<Animator>();
    hasTimedOut = false;
    startTimer = false;
  }

  private void Update()
  {
    if (startTimer)
    {
      duration -= Time.deltaTime;
    }

    if (duration < 0)
    {
      duration = 0.00f;
      if (!hasTimedOut)
      {
        hasTimedOut = true;
        mainGameStateMachine.SetTrigger("Time Out");
      }
    }

    display.text = string.Format("Time Remaining: {0} seconds", duration.ToString("F2"));
  }
}
